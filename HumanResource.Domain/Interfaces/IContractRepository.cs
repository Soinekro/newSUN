using CommonClass.Querying;
using HumanResource.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HumanResource.Domain.Interfaces;
public interface IContractRepository
{
    Task<Contract> CreateAsync(Contract contract);
    Task<Contract?> GetContract(int contractId, ApiQuerySpec query);
}