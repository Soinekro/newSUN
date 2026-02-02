using CommonClass.Infrastructure.Persistence.Repositories;
using HumanResource.Domain.Entities;
using HumanResource.Domain.Interfaces;
using HumanResource.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HumanResource.Infrastructure.Repositories;
public class ContractRepository(HumanResourceDbContext context)
    : BaseRepository<Contract, HumanResourceDbContext>(context), IContractRepository
{
    // Solo defines la "Lista Blanca" de includes
    protected override Dictionary<string, Func<IQueryable<Contract>, IQueryable<Contract>>> AllowedIncludes => new(StringComparer.OrdinalIgnoreCase)
    {
        ["employee"] = q => q.Include(c => c.Employee)
    };

    // Si tuvieras métodos personalizados extra, van aquí.
    // GetAll, GetById, Create, etc., ya vienen heredados.
}
