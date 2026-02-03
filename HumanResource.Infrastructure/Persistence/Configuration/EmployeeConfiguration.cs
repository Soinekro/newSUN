using HumanResource.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HumanResource.Infrastructure.Persistence.Configuration
{
    public partial class HumanResourceDbContext : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> b)
        {
            b.ToTable("HrEmployees");
            b.HasKey(x => x.EmployeeId);
            b.Property(x => x.FirstName).HasMaxLength(100).IsRequired();
            b.Property(x => x.LastName).HasMaxLength(100).IsRequired();
            b.Property(x => x.Email).HasMaxLength(150).IsRequired();
            b.Property(x => x.PhoneNumber).HasMaxLength(20);
            b.Property(x => x.DateOfBirth).IsRequired();

            b.HasMany(x => x.Contracts)
                 .WithOne(c => c.Employee)
                 .HasForeignKey(c => c.EmployeeId);
        }
    }
}
