using CommonClass.Infrastructure.Persistence.Repositories;
using __Module__.Domain.Entities;
using __Module__.Domain.Interfaces;
using __Module__.Infrastructure.Persistence.Context; // Asume que aquí está el DbContext
using System.Linq.Expressions;

namespace __Module__.Infrastructure.Repositories;

public class __Entity__Repository(__Module__DbContext context) 
    : BaseRepository<__Entity__, __Module__DbContext>(context), I__Entity__Repository
{
    protected override Dictionary<string, Func<IQueryable<__Entity__>, IQueryable<__Entity__>>> AllowedIncludes => new(StringComparer.OrdinalIgnoreCase)
    {
        // ["algo"] = q => q.Include(x => x.Algo)
    };
    
    // Configura sort por defecto si quieres
    protected override Dictionary<string, Expression<Func<__Entity__, object?>>> AllowedSorts => new(StringComparer.OrdinalIgnoreCase)
    {
        // ["id"] = x => x.Id
    };
}