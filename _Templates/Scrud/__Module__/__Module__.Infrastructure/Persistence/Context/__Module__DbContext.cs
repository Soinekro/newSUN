using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace __Module_.Infrastructure.Persistence.Context;

// ✅ Este define el constructor primario y llama a la base
public partial class __Module_DbContext(DbContextOptions<__Module_DbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}