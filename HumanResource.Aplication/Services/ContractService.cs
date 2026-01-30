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

    public async Task<BaseResponse<ContractResponse>> GetContract(int contractId)
    {
        Contract? contract = await _contractRepository.GetContract(contractId);
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
        var response = new ContractResponse
        {
            CtrId = contract.CtrId,
            StartDate = contract.StartDate,
            EndDate = contract.EndDate,
            Employee = new EmployeeResponse
            {
                EmployeeId = contract.Employee.EmployeeId,
                FirstName = contract.Employee.FirstName,
                LastName = contract.Employee.LastName,
                Email = contract.Employee.Email
            }
        };
        return new BaseResponse<ContractResponse>
        {
            IsSuccess = true,
            Message = "Contract retrieved successfully.",
            StatusCode = 200,
            Data = response
        };
    }
}
