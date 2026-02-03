using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace HumanResource.Infrastructure.Persistence;

// Esta es la definición principal de la clase
public partial class HumanResourceDbContext(DbContextOptions<HumanResourceDbContext> options) : DbContext(options)
{
    // NO pongas DbSets aquí si quieres que estén separados.

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}