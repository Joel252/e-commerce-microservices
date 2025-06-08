using Microservices.Web.Models;
using Microservices.Web.Service.IService;
using Microservices.Web.Utility;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Microservices.Web.Controllers
{
    /// <summary>
    /// Controller responsible for handling authentication-related operations, including login, logout, and registration.
    /// </summary>
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly ITokenProvider _tokenProvider;
        private readonly IUserAuthenticator _userAuthenticator;

        public AuthController(IAuthService authService, ITokenProvider tokenProvider,
            IUserAuthenticator userAuthenticator)
        {
            _authService = authService;
            _tokenProvider = tokenProvider;
            _userAuthenticator = userAuthenticator;
        }

        // Action to load the login view
        public IActionResult LogIn()
        {
            LoginRequestDto loginRequestDto = new();
            return View(loginRequestDto);
        }

        // POST: Action to process the login request
        [HttpPost]
        public async Task<IActionResult> LogIn(LoginRequestDto request)
        {
            // Validate the model state before proceeding with login
            if (!ModelState.IsValid) return View(request);

            // Check if the login request is successful
            var response = await _authService.Login(request);
            if (!response?.IsSuccess == true)
            {
                TempData["error"] = response?.Message;
                return View(request);
            }

            // Check if the response contains a valid user object
            var loginResponse =
                JsonConvert.DeserializeObject<LoginResponseDto>(Convert.ToString(response?.Result) ?? "null");
            if (loginResponse?.User == null)
            {
                TempData["error"] = "Login failed. Please try again.";
                return View(request);
            }

            // Set the authentication cookie
            _tokenProvider.SetToken(loginResponse.Token);

            // Authenticate the user using the token in .NET Core Identity
            await _userAuthenticator.AuthenticateUserAsync(loginResponse.Token);

            TempData["success"] = "Login successful!";
            return RedirectToAction("Index", "Home");
        }

        // Action to clear the authentication cookie
        public async Task<IActionResult> LogOut()
        {
            // Clear the authentication cookie
            await HttpContext.SignOutAsync();
            _tokenProvider.ClearToken();

            TempData["success"] = "Logout successful!";
            return RedirectToAction("Index", "Home");
        }

        // Action to load the registration view
        public IActionResult Register()
        {
            ViewBag.RoleList = RoleListHelper.GetRoleList();
            return View();
        }

        // POST: Action to process the registration request
        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequestDto request)
        {
            var roleList = RoleListHelper.GetRoleList();

            // Validate the model state before proceeding with registration
            if (!ModelState.IsValid)
            {
                ViewBag.RoleList = roleList;
                return View(request);
            }

            // Check if the registration request is successful
            var response = await _authService.Register(request);
            if (!response?.IsSuccess == true)
            {
                TempData["error"] = response?.Message;
                ViewBag.RoleList = roleList;
                return View(request);
            }

            // If the role is not specified, default to Customer
            if (string.IsNullOrWhiteSpace(request.Role))
            {
                request.Role = nameof(SD.RoleType.Customer);
            }

            // Check if the assigning role is valid
            var roleResponse = await _authService.AssignRole(request);
            if (!roleResponse?.IsSuccess == true)
            {
                TempData["error"] = roleResponse?.Message;
                ViewBag.RoleList = roleList;
                return View(request);
            }

            TempData["success"] = "User registered successfully!";
            return RedirectToAction(nameof(LogIn));
        }
    }
}