using HumanResource.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HumanResource.Infrastructure.Persistence;

public partial class HumanResourceDbContext(DbContextOptions<HumanResourceDbContext> options) : DbContext(options)
{
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<Contract> Contracts => Set<Contract>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        ConfigureEmployee(modelBuilder);
        ConfigureContract(modelBuilder);
    }

    partial void ConfigureEmployee(ModelBuilder modelBuilder);
    partial void ConfigureContract(ModelBuilder modelBuilder);
}
