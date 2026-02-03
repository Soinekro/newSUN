using CommonClass.Infrastructure.Persistence.Repositories;
using ReceptionFresh.Domain.Entities;
using ReceptionFresh.Domain.Interfaces;
using ReceptionFresh.Infrastructure.Persistence.Context; // Asume que aquí está el DbContext
using System.Linq.Expressions;

namespace ReceptionFresh.Infrastructure.Repositories;

public class PalletRepository(ReceptionFreshDbContext context) 
    : BaseRepository<Pallet, ReceptionFreshDbContext>(context), IPalletRepository
{
    protected override Dictionary<string, Func<IQueryable<Pallet>, IQueryable<Pallet>>> AllowedIncludes => new(StringComparer.OrdinalIgnoreCase)
    {
        // ["algo"] = q => q.Include(x => x.Algo)
    };
    
    // Configura sort por defecto si quieres
    protected override Dictionary<string, Expression<Func<Pallet, object?>>> AllowedSorts => new(StringComparer.OrdinalIgnoreCase)
    {
        // ["id"] = x => x.Id
    };
}