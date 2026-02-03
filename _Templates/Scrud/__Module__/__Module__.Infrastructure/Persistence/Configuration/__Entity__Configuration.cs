using __Module__.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace __Module__.Infrastructure.Persistence.Configuration;

public class __Entity__Configuration : IEntityTypeConfiguration<__Entity__>
{
    public void Configure(EntityTypeBuilder<__Entity__> builder)
    {
        // Nombre de la tabla
        builder.ToTable("__Entity__"); // O la convención que uses

        // Primary Key
        builder.HasKey(x => x.__Entity__Id);

        // Configuraciones adicionales
        // builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
    }
}