using Microservices.Services.AuthAPI.Data;
using Microservices.Services.AuthAPI.Models;
using Microservices.Services.AuthAPI.Models.DTO;
using Microservices.Services.AuthAPI.Service.IService;
using Microsoft.AspNetCore.Identity;

namespace Microservices.Services.AuthAPI.Service
{
    public class AuthService : IAuthService
    {
        private readonly AuthDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

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

        public Task<ApplicationUserDto> Register(RegisterRequestDto registerRequestDto)
        {
            throw new NotImplementedException();
        }
    }
}
