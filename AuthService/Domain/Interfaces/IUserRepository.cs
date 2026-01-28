using AuthService.Domain.Entities;

namespace AuthService.Domain.Interfaces;

/// <summary>
/// Define el contrato para el repositorio de usuarios.
/// Esta interfaz pertenece a la capa de Dominio y abstrae los detalles de la persistencia de datos.
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// Busca un usuario por su nombre de usuario de forma asíncrona.
    /// </summary>
    /// <param name="username">El nombre de usuario a buscar.</param>
    /// <returns>
    /// Una tarea que representa la operación asíncrona.
    /// El resultado de la tarea contiene la entidad del usuario si se encuentra; de lo contrario, null.
    /// </returns>
    Task<User?> GetByUsernameAsync(string username);

    /// <summary>
    /// Indica si ya existe un usuario con el username especificado.
    /// </summary>
    /// <param name="username">Username a validar.</param>
    Task<bool> ExistsByUsernameAsync(string username);

    /// <summary>
    /// Crea un nuevo usuario y lo persiste.
    /// </summary>
    /// <param name="user">Entidad de usuario a crear.</param>
    Task<User> CreateAsync(User user);
}
