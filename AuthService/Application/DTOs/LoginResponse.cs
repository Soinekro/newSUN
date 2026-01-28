namespace AuthService.Application.DTOs;

/// <summary>
/// Representa la respuesta de datos tras un inicio de sesión exitoso.
/// Contiene el token de acceso que el cliente debe usar para autenticarse en solicitudes posteriores.
/// </summary>
public class LoginResponse
{
    /// <summary>
    /// Token de acceso JWT (JSON Web Token).
    /// </summary>
    public string AccessToken { get; set; } = string.Empty;
}
