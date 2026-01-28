using AuthService.Domain.Entities;

namespace AuthService.Application.Interfaces;

/// <summary>
/// Define el contrato para el servicio que genera tokens JWT.
/// </summary>
public interface IJwtTokenService
{
    /// <summary>
    /// Genera un token JWT para un usuario específico.
    /// </summary>
    /// <param name="user">El usuario para el cual se generará el token.</param>
    /// <returns>El token JWT como string.</returns>
    string GenerateToken(User user);
}
