using ReceptionFresh.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ReceptionFresh.Infrastructure.Persistence.Configuration;

public class PalletConfiguration : IEntityTypeConfiguration<Pallet>
{
    public void Configure(EntityTypeBuilder<Pallet> builder)
    {
        // Nombre de la tabla
        builder.ToTable("Pallet"); // O la convención que uses

        // Primary Key
        builder.HasKey(x => x.PalletId);

        // Configuraciones adicionales
        // builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
    }
}