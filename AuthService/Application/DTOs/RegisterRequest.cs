using System.ComponentModel.DataAnnotations;

namespace AuthService.Application.DTOs;

/// <summary>
/// DTO de entrada para registrar un nuevo usuario en el sistema.
/// Este DTO es específico del AuthService.
/// </summary>
public class RegisterRequest
{
 /// <summary>
 /// Nombre de usuario. Debe ser único.
 /// </summary>
 [Required(ErrorMessage = "El nombre de usuario es obligatorio.")]
 [StringLength(50, MinimumLength =3, ErrorMessage = "El usuario debe tener entre3 y50 caracteres.")]
 public string Username { get; set; } = string.Empty;

 /// <summary>
 /// Contraseña en texto plano (solo viaja en la request). Nunca se almacena así.
 /// </summary>
 [Required(ErrorMessage = "La contraseña es obligatoria.")]
 [StringLength(100, MinimumLength =6, ErrorMessage = "La contraseña debe tener al menos6 caracteres.")]
 public string Password { get; set; } = string.Empty;

 /// <summary>
 /// Id del usuario que crea el registro (auditoría).
 /// En escenarios públicos puede ser0 o null y lo asignas como "system".
 /// </summary>
 public int? CreatedByUserId { get; set; }
}
