using CommonClass.Querying;
using HumanResource.Domain.Entities;
using HumanResource.Domain.Interfaces;
using HumanResource.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HumanResource.Infrastructure.Repositories;
public class ContractRepository(HumanResourceDbContext context) : IContractRepository
{
    private readonly HumanResourceDbContext _context = context;

    public async Task<Contract> CreateAsync(Contract contract)
    {
        _context.Contracts.Add(contract);
        await _context.SaveChangesAsync();
        return contract;
    }

    public async Task<Contract?> GetContract(int contractId, ApiQuerySpec query)
    {
        var allowedIncludes = new Dictionary<string, Func<IQueryable<Contract>, IQueryable<Contract>>>(StringComparer.OrdinalIgnoreCase)
        {
            ["employee"] = q => q.Include(x => x.Employee),

        };

        IQueryable<Contract> contract = _context.Contracts
            .AsNoTracking()
            .Where(c => c.CtrId == contractId)
            .ApplyIncludes(query.Relations, allowedIncludes);

        return await contract.SingleOrDefaultAsync();
    }
}
