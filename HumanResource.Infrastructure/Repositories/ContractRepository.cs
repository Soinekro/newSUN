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

    public async Task<Contract?> GetContract(int contractId)
    {
        return await _context.Contracts.Include(c=>c.Employee)
            .FirstOrDefaultAsync(c=>c.CtrId == contractId);
    }
}
