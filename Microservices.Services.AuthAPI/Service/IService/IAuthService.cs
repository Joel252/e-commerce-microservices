using Microservices.Services.AuthAPI.Models.DTO;

namespace Microservices.Services.AuthAPI.Service.IService
{
    public interface IAuthService
    {
        Task<ApplicationUserDto> Register(RegisterRequestDto registerRequestDto);
        Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);
    }
}
