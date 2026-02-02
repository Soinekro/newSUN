using CommonClass.Infrastructure.Persistence.Repositories;
using HumanResource.Domain.Entities;
using HumanResource.Domain.Interfaces;
using HumanResource.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HumanResource.Infrastructure.Repositories;

public class EmployeeRepository(HumanResourceDbContext context)
    : BaseRepository<Employee, HumanResourceDbContext>(context), IEmployeeRepository
{
    protected override Dictionary<string, Func<IQueryable<Employee>, IQueryable<Employee>>> AllowedIncludes => new(StringComparer.OrdinalIgnoreCase)
    {
        ["contracts"] = q => q.Include(e => e.Contracts)
    };

    protected override Dictionary<string, Expression<Func<Employee, object?>>> AllowedSorts => new(StringComparer.OrdinalIgnoreCase)
    {
        ["id"] = e => e.EmployeeId,
        ["firstname"] = e => e.FirstName,
        // ... resto ...
    };

    // Filtros manuales si BaseRepository no tiene filtro genérico:
    // Puedes sobreescribir GetAllAsync si necesitas lógica muy custom.
}