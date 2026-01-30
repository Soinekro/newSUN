using HumanResource.Domain.Entities;

namespace HumanResource.Domain.Interfaces;
public interface IContractRepository
{
    Task<Contract> CreateAsync(Contract contract);
    Task<Contract?> GetContract(int contractId);
}