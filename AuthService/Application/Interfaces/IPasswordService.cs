namespace AuthService.Application.Interfaces;

/// <summary>
/// Define el contrato para el servicio que maneja hashing y verificación de contraseñas.
/// </summary>
public interface IPasswordService
{
 /// <summary>
 /// Genera un hash seguro a partir de una contraseña en texto plano.
 /// El resultado incluye el salt y el formato necesario para verificarla posteriormente.
 /// </summary>
 /// <param name="password">Contraseña en texto plano.</param>
 /// <returns>Hash persistible en base de datos.</returns>
 string HashPassword(string password);

 /// <summary>
 /// Verifica si una contraseña en texto plano coincide con el hash almacenado.
 /// </summary>
 /// <param name="password">La contraseña proporcionada por el usuario.</param>
 /// <param name="passwordHash">El hash almacenado en la base de datos.</param>
 /// <returns>True si coinciden, False en caso contrario.</returns>
 bool VerifyPassword(string password, string passwordHash);
}
