using CommonClass.Querying;
using CommonClass.Response;
using HumanResource.Aplication.DTOs.Mappers;
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

        var response = contract.ToResponse();

        return new BaseResponse<ContractResponse>
        {
            IsSuccess = true,
            Message = "Contract created successfully.",
            StatusCode = 201,
            Data = response
        };

    }

    public async Task<BaseResponse<ContractResponse>> GetContract(int contractId, ApiQuerySpec query)
    {
        Contract? contract = await _contractRepository.GetContract(contractId, query);
        if (contract == null)
        {
            return new BaseResponse<ContractResponse>
            {
                IsSuccess = false,
                Message = "Contract not found.",
                StatusCode = 404,
                Data = null
            };
        }
        var response = contract.ToResponse(query);
        return new BaseResponse<ContractResponse>
        {
            IsSuccess = true,
            Message = "Contract retrieved successfully.",
            StatusCode = 200,
            Data = response
        };
    }
}
