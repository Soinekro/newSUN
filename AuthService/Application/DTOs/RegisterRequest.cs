using Api.Common.Validates;
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
    [Display(Name = "nombre de usuario")]
    [RequiredEx]
    [MaxLengthEx(12)]
    [MinLengthEx(4)]
    public string Username { get; set; } = string.Empty;

    /// <summary>
    /// Contraseña en texto plano (solo viaja en la request). Nunca se almacena así.
    /// </summary>
    [RequiredEx]
    [Display(Name = "contraseña")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;

    /// <summary>
    /// Id del usuario que crea el registro (auditoría).
    /// En escenarios públicos puede ser0 o null y lo asignas como "system".
    /// </summary>
    /// 
    [RequiredEx]
    public int? CreatedByUserId { get; set; }
}
