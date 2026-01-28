namespace AuthService.Application.DTOs;

/// <summary>
/// DTO de salida al registrar un usuario.
/// </summary>
public class RegisterResponse
{
 /// <summary>
 /// Identificador del usuario creado.
 /// </summary>
 public int Id { get; set; }

 /// <summary>
 /// Username del usuario creado.
 /// </summary>
 public string Username { get; set; } = string.Empty;
}
