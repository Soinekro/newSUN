using System.ComponentModel.DataAnnotations;

namespace AuthService.Application.DTOs;

/// <summary>
/// Representa la solicitud de datos para el inicio de sesión de un usuario.
/// Contiene las credenciales necesarias para la autenticación.
/// </summary>
public class LoginRequest
{
    /// <summary>
    /// Nombre de usuario. Es obligatorio.
    /// </summary>
    [Required(ErrorMessage = "El nombre de usuario es obligatorio.")]
    public string Username { get; set; } = string.Empty;

    /// <summary>
    /// Contraseña del usuario. Es obligatoria.
    /// </summary>
    [Required(ErrorMessage = "La contraseña es obligatoria.")]
    public string Password { get; set; } = string.Empty;
}
