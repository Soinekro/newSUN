using HumanResource.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HumanResource.Infrastructure.Persistence;

public partial class HumanResourceDbContext
{
    partial void ConfigureContract(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contract>(b =>
        {
            b.ToTable("HrContracts");
            b.HasKey(x => x.CtrId);
            b.Property(x => x.EmployeeId).IsRequired();
            b.Property(x => x.StartDate).IsRequired();
            b.Property(x => x.EndDate).IsRequired();
            b.Property(x => x.Salary).IsRequired().HasPrecision(18, 4);
            b.Property(x => x.Position).IsRequired();

            b.HasOne(x => x.Employee)
             .WithMany(e => e.Contracts)
             .HasForeignKey(x => x.EmployeeId)
             .OnDelete(DeleteBehavior.Restrict);
        });
    }
}