using Microservices.Services.AuthAPI.Models;
using Microservices.Services.AuthAPI.Models.DTO;
using Microservices.Services.AuthAPI.Service.IService;
using Microsoft.AspNetCore.Identity;

namespace Microservices.Services.AuthAPI.Service
{
    /// <summary>
    /// Service class for handling authentication-related operations.
    /// </summary>
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthService"/> class.
        /// </summary>
        /// <param name="userManager">The user manager used to manage user accounts and authentication.</param>
        /// <param name="roleManager">The role manager used to manage user roles and permissions.</param>
        /// <param name="jwtTokenGenerator">The JWT token generator used to generate JSON Web Tokens (JWT).</param>
        public AuthService(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IJwtTokenGenerator jwtTokenGenerator
        )
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        /// <summary>
        /// Authenticates a user based on the provided login credentials.
        /// </summary>
        /// <param name="loginRequestDto">The login request containing the user's username and password.</param>
        /// <returns>A <see cref="LoginResponseDto"/> containing the authenticated user's details and a token if the login is
        /// successful; otherwise, a response with a null user if authentication fails.</returns>
        public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
        {
            var user = _userManager.Users.FirstOrDefault(u => u.UserName == loginRequestDto.UserName);

            // Check if the user exists
            if (user == null)
            {
                return new LoginResponseDto { User = null };
            }

            // Check if the password is correct
            var result = await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);
            if (!result)
            {
                return new LoginResponseDto { User = null };
            }

            // Generate a JWT token for the user
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new LoginResponseDto
            {
                User = new ApplicationUserDto
                {
                    ID = user.Id,
                    Name = user.Name,
                    Email = user.Email!,
                    PhoneNumber = user.PhoneNumber!,
                },
                Token = token
            };
        }

        /// <summary>
        /// Assigns a specified role to a user identified by their email address.
        /// </summary>
        /// <param name="email">The email address of the user to whom the role will be assigned.</param>
        /// <param name="role">The role to be assigned to the user.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating whether
        /// the role assignment was successful.</returns>
        public async Task<bool> AssignRole(string email, string role)
        {
            var user = _userManager.Users.FirstOrDefault(u => u.Email!.ToLower() == email.ToLower());

            // Check if the user exists 
            if (user == null) return false;

            // Check if the role exists
            if (!await _roleManager.RoleExistsAsync(role))
            {
                // If the role doesn't exist, create it
                var roleResult = await _roleManager.CreateAsync(new IdentityRole(role));
                if (!roleResult.Succeeded) return false;
            }

            var result = await _userManager.AddToRoleAsync(user, role);
            return result.Succeeded;
        }

        /// <summary>
        /// Registers a new user with the provided registration details.
        /// </summary>
        /// <param name="registerRequestDto">An object containing the user's registration details, including email, name, phone number, and password.</param>
        /// <returns>A string containing an error message if the registration fails, or an empty string if the registration is successful.</returns>
        /// <exception cref="Exception">Thrown if an unexpected error occurs during the registration process.</exception>
        public async Task<string> Register(RegisterRequestDto registerRequestDto)
        {
            ApplicationUser user = new()
            {
                UserName = registerRequestDto.Email,
                Email = registerRequestDto.Email,
                NormalizedEmail = registerRequestDto.Email.ToUpper(),
                Name = registerRequestDto.Name,
                PhoneNumber = registerRequestDto.PhoneNumber
            };

            try
            {
                // Create the user in the database using UserManager
                var result = await _userManager.CreateAsync(user, registerRequestDto.Password);

                // Check if the user was created successfully
                if (!result.Succeeded)
                {
                    // If there are errors, return the first error message
                    return result.Errors.FirstOrDefault()?.Description ?? "User registration failed.";
                }

                return string.Empty;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while registering the user.", ex);
            }
        }
    }
}
