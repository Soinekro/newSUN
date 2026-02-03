using HumanResource.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HumanResource.Infrastructure.Persistence.Configuration;

public class ContractConfiguration : IEntityTypeConfiguration<Contract>
{
    public void Configure(EntityTypeBuilder<Contract> b)
    {
        b.ToTable("HrContracts"); // Usa nombres en plural o convención estándar
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
    }
}