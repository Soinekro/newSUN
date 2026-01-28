using AuthService.Application.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace AuthService.Infrastructure.Services;

/// <summary>
/// Servicio para generar y verificar hashes de contraseñas.
/// 
/// Implementación basada en <see cref="PasswordHasher{TUser}"/>, que usa PBKDF2
/// e incluye salt y parámetros en el hash resultante.
/// </summary>
public class PasswordService : IPasswordService
{
    // No usamos un usuario real en este microservicio, por eso usamos object como placeholder.
    private readonly PasswordHasher<object> _passwordHasher = new();
    private static readonly object _userContext = new();

    /// <summary>
    /// Genera un hash seguro para almacenar en base de datos.
    /// </summary>
    public string HashPassword(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
            throw new ArgumentException("La contraseña no puede estar vacía.", nameof(password));

        return _passwordHasher.HashPassword(_userContext, password);
    }

    /// <summary>
    /// Verifica la contraseña en texto plano contra el hash almacenado.
    /// </summary>
    public bool VerifyPassword(string password, string passwordHash)
    {
        if (string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(passwordHash))
            return false;

        var result = _passwordHasher.VerifyHashedPassword(_userContext, passwordHash, password);
        return result == PasswordVerificationResult.Success || result == PasswordVerificationResult.SuccessRehashNeeded;
    }
}
