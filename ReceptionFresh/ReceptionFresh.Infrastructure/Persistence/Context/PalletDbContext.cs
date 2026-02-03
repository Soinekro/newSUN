using Microsoft.EntityFrameworkCore;
using ReceptionFresh.Domain.Entities;

namespace ReceptionFresh.Infrastructure.Persistence.Context;
public partial class ReceptionFreshDbContext
{
    public DbSet<Pallet> Pallets => Set<Pallet>();
}