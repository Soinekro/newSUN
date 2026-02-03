using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ReceptionFresh.Infrastructure.Persistence.Context;

// ✅ Este define el constructor primario y llama a la base
public partial class ReceptionFreshDbContext(DbContextOptions<ReceptionFreshDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}