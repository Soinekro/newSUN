using HumanResource.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HumanResource.Infrastructure.Persistence;
public partial class ContractDbContext(DbContextOptions<ContractDbContext> options) : DbContext(options)
{
    public DbSet<Contract> Contracts => Set<Contract>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Contract>(b =>
        {
            b.ToTable("HrContracts");
            b.HasKey(x => x.CtrId);
            b.Property(x => x.EmployeeId).IsRequired();
            b.Property(x => x.StartDate).IsRequired();
            b.Property(x => x.EndDate).IsRequired();
            b.Property(x => x.Salary).IsRequired();
            b.Property(x => x.Position).IsRequired();
            b.HasOne(x => x.Employee)
             .WithMany()
             .HasForeignKey(x => x.EmployeeId)
             .OnDelete(DeleteBehavior.Restrict);
        });
    }

}
