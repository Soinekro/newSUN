using AuthService.Domain.Entities;
using AuthService.Domain.Interfaces;
using AuthService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Infrastructure.Repositories;

/// <summary>
/// Repositorio de usuarios usando EF Core.
/// </summary>
public class UserRepository : IUserRepository
{
    private readonly AuthDbContext _db;

    public UserRepository(AuthDbContext db)
    {
        _db = db;
    }

    public Task<User?> GetByUsernameAsync(string username)
        => _db.Users.AsNoTracking().SingleOrDefaultAsync(u => u.Username == username);

    public Task<bool> ExistsByUsernameAsync(string username)
        => _db.Users.AsNoTracking().AnyAsync(u => u.Username == username);

    public async Task<User> CreateAsync(User user)
    {
        _db.Users.Add(user);
        await _db.SaveChangesAsync();
        return user;
    }
}