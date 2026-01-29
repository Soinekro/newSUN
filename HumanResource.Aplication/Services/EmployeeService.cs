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
}
