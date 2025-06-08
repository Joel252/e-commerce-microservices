using Microservices.Web.Models;
using Microservices.Web.Service.IService;
using Microservices.Web.Utility;

namespace Microservices.Web.Service;

/// <summary>
/// Provides authentication-related services including user registration, login,
/// and role assignment by interacting with an underlying base service.
/// </summary>
public class AuthService : IAuthService
{
    private readonly IBaseService _baseService;
    private const string RESOURCE = "/api/auth";

    /// <summary>
    /// Constructor for AuthService.
    /// </summary>
    /// <param name="baseService">Request service.</param>
    public AuthService(IBaseService baseService)
    {
        _baseService = baseService;
    }

    /// <summary>
    /// Registers a new user by sending their information to the authentication API.
    /// </summary>
    /// <param name="registerRequestDto">The data transfer object containing user registration details.</param>
    /// <returns>A task that represents the asynchronous operation, containing a ResponseDto object with the result of the registration process.</returns>
    public async Task<ResponseDto?> Register(RegisterRequestDto registerRequestDto)
    {
        return await _baseService.SendAsync(new RequestDto
        {
            RequestType = SD.RequestType.Post,
            Url = SD.AuthApiBase + $"{RESOURCE}/register",
            Data = registerRequestDto
        }, isAuthRequired: false);
    }

    /// <summary>
    /// Authenticates a user by validating the provided login credentials.
    /// </summary>
    /// <param name="loginRequestDto">The login request data transfer object containing user credentials.</param>
    /// <returns>A task that represents the asynchronous operation, containing a response DTO with the result of the login attempt.</returns>
    public async Task<ResponseDto?> Login(LoginRequestDto loginRequestDto)
    {
        return await _baseService.SendAsync(new RequestDto
        {
            RequestType = SD.RequestType.Post,
            Url = SD.AuthApiBase + $"{RESOURCE}/login",
            Data = loginRequestDto
        }, isAuthRequired: false);
    }

    /// <summary>
    /// Assigns a role to a user by interacting with the base service.
    /// </summary>
    /// <param name="registerRequestDto">The registration request data, which includes user details and the role to be assigned.</param>
    /// <returns>A ResponseDto object indicating the success or failure of the role assignment operation.</returns>
    public async Task<ResponseDto?> AssignRole(RegisterRequestDto registerRequestDto)
    {
        return await _baseService.SendAsync(new RequestDto
        {
            RequestType = SD.RequestType.Post,
            Url = SD.AuthApiBase + $"{RESOURCE}/assignRole",
            Data = registerRequestDto
        });
    }
}