using Api.Common.Response;
using AuthService.Application.DTOs;

namespace AuthService.Application.Interfaces;

/// <summary>
/// Contrato del servicio de autenticación.
/// </summary>
public interface IAuthService
{
    Task<BaseResponse<LoginResponse>> LoginAsync(LoginRequest request);

    Task<BaseResponse<RegisterResponse>> RegisterAsync(RegisterRequest request);
}
