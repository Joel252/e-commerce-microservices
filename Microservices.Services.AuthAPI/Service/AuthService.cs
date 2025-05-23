using Microservices.Services.AuthAPI.Data;
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
        private readonly AuthDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthService"/> class.
        /// </summary>
        /// <param name="context">The database context used for authentication-related data operations.</param>
        /// <param name="userManager">The user manager used to manage user accounts and authentication.</param>
        /// <param name="roleManager">The role manager used to manage user roles and permissions.</param>
        public AuthService(AuthDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
        {
            throw new NotImplementedException();
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
