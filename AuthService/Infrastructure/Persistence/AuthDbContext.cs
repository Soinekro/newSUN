using AuthService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace AuthService.Infrastructure.Persistence;

/// <summary>
/// DbContext del microservicio de autenticación.
/// Contiene el mapeo de entidades del AuthService.
/// </summary>
public class AuthDbContext : DbContext
{
    public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options) { }

    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(b =>
        {
            b.ToTable("SecUsers"); // nombre recomendado (tabla "de seguridad")
            b.HasKey(x => x.Id);

            b.Property(x => x.Username).HasMaxLength(50).IsRequired();
            b.HasIndex(x => x.Username).IsUnique();

            b.Property(x => x.PasswordHash).HasMaxLength(200).IsRequired();

            // Soft delete por defecto (SecStatus = true)
            b.HasQueryFilter(x => x.SecStatus);
        });
    }
}