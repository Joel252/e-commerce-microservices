using Microservices.Web.Models;
using Microservices.Web.Service.IService;
using Microservices.Web.Utility;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Microservices.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        // GET: AuthController/Login
        public IActionResult LogIn()
        {
            LoginRequestDto loginRequestDto = new();
            return View(loginRequestDto);
        }

        // GET: AuthController/Logout
        public IActionResult LogOut()
        {
            return View();
        }

        // POST: AuthController/Login
        [HttpPost]
        public async Task<IActionResult> LogIn(LoginRequestDto request)
        {
            // Validate the model state before proceeding with login
            if (!ModelState.IsValid) return View(request);

            // Check if the login request is successful
            var response = await _authService.Login(request);
            if (!response.IsSuccess)
            {
                ModelState.AddModelError("CustomError", response.Message);
                return View(request);
            }

            // Check if the response contains a valid user object
            var loginResponse = JsonConvert.DeserializeObject<LoginResponseDto>(Convert.ToString(response.Result));
            if (loginResponse == null || loginResponse.User == null)
            {
                TempData["error"] = "Login failed. Please try again.";
                return View(request);
            }

            // Set the authentication cookie
            TempData["success"] = "Login successful!";
            return RedirectToAction("Index", "Home");
        }

        // GET: AuthController/Register
        public IActionResult Register()
        {
            ViewBag.RoleList = RoleListHelper.GetRoleList();
            return View();
        }

        // POST: AuthController/Register
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
            if (!response.IsSuccess)
            {
                TempData["error"] = response.Message;
                ViewBag.RoleList = roleList;
                return View(request);
            }

            // If the role is not specified, default to Customer
            if (string.IsNullOrWhiteSpace(request.Role))
            {
                request.Role = SD.RoleType.Customer.ToString();
            }

            // Check if the assigning role is valid
            var roleResponse = await _authService.AssignRole(request);
            if (!roleResponse.IsSuccess)
            {
                TempData["error"] = roleResponse.Message;
                ViewBag.RoleList = roleList;
                return View(request);
            }

            TempData["success"] = "User registered successfully!";
            return RedirectToAction(nameof(LogIn));
        }
    }
}