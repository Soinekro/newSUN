using CommonClass.Response;
using HumanResource.Aplication.DTOs.Request;
using HumanResource.Aplication.DTOs.Responses;
using HumanResource.Aplication.Interfaces;
using HumanResource.Domain.Entities;
using HumanResource.Domain.Interfaces;

namespace HumanResource.Aplication.Services;

public class EmployeeService(IEmployeeRepository employeeRepository) : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository = employeeRepository;

    public async Task<BaseResponse<EmployeeResponse>> CreateAsync(EmployeeRequest request)
    {
        var employeeModel = new Employee
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            DateOfBirth = request.DateOfBirth,
            PhoneNumber = request.Phone
        };

        Employee employee = await _employeeRepository.CreateAsync(employeeModel);

        var response = new EmployeeResponse
        {
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Email = employee.Email,
            Phone = employee.PhoneNumber
        };

        return new BaseResponse<EmployeeResponse>
        {
            IsSuccess = true,
            Message = "Employee created successfully",
            StatusCode = 201,
            Data = response
        };
    }

    public async Task<BaseResponse<EmployeeResponse>> GetEmployee(int employeeId)
    {
        Employee? employee = await _employeeRepository.GetEmployee(employeeId);
        if (employee == null)
        {
            return new BaseResponse<EmployeeResponse>
            {
                IsSuccess = false,
                Message = "Employee not found.",
                StatusCode = 404,
                Data = null
            };
        }
        var response = new EmployeeResponse
        {
            EmployeeId = employee.EmployeeId,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Email = employee.Email,
            Phone = employee.PhoneNumber,
            Contracts = employee.Contracts?.Select(c => new ContractResponse
            {
                CtrId = c.CtrId,
                StartDate = c.StartDate,
                EndDate = c.EndDate
            }).ToList() ?? new List<ContractResponse>()
        };
        return new BaseResponse<EmployeeResponse>
        {
            IsSuccess = true,
            Message = "Employee retrieved successfully.",
            StatusCode = 200,
            Data = response
        };
    }
}
