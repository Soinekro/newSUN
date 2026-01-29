using CommonClass.Response;
using HumanResource.Aplication.DTOs.Request;
using HumanResource.Aplication.DTOs.Responses;
using HumanResource.Aplication.Interfaces;
using HumanResource.Domain.Entities;
using HumanResource.Domain.Interfaces;

namespace HumanResource.Aplication.Services;
public class ContractService(IContractRepository contractRepository) : IContractService
{
    private readonly IContractRepository _contractRepository = contractRepository;
    public async Task<BaseResponse<ContractResponse>> CreateAsync(ContractRequest request)
    {
        var contractModel = new Contract
        {
            EmployeeId = request.EmployeeId,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            Position = request.Position,
            Salary = request.Salary
        };
        Contract contract = await _contractRepository.CreateAsync(contractModel);
        var response = new ContractResponse
        {
            CtrId = contract.CtrId,
            StartDate = contract.StartDate,
            EndDate = contract.EndDate,
        };
        return new BaseResponse<ContractResponse>
        {
            IsSuccess = true,
            Message = "Contract created successfully.",
            StatusCode = 201,
            Data = response
        };

    }
}
