using System.ComponentModel.DataAnnotations;
using CommonClass.Validates;

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
    [Display(Name = "nombre de usuario")]
    [RequiredEx]
    public string Username { get; set; } = string.Empty;

    /// <summary>
    /// Contraseña del usuario. Es obligatoria.
    /// </summary>
    [Display(Name = "contraseña")]
    [RequiredEx]
    public string Password { get; set; } = string.Empty;
}
