using Api.Common.Class;

namespace AuthService.Domain.Entities;

/// <summary>
/// Representa la entidad de un usuario en el dominio de la aplicación.
/// Esta clase es el núcleo del modelo de usuario y no debe contener dependencias externas.
/// </summary>
public class User : BaseAuditableClass
{
    /// <summary>
    /// Identificador único del usuario.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Nombre de usuario para el inicio de sesión.
    /// </summary>
    public string Username { get; set; } = string.Empty;

    /// <summary>
    /// Hash de la contraseña del usuario.
    /// Nunca se debe almacenar la contraseña en texto plano.
    /// </summary>
    public string PasswordHash { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

}
