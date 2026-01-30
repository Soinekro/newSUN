using CommonClass.Querying;
using CommonClass.Response;
using HumanResource.Aplication.DTOs.Mappers;
using HumanResource.Aplication.DTOs.Request;
using HumanResource.Aplication.DTOs.Responses;
using HumanResource.Aplication.Interfaces;
using HumanResource.Domain.Entities;
using HumanResource.Domain.Interfaces;

namespace HumanResource.Aplication.Services;

public class EmployeeService(IEmployeeRepository employeeRepository) : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository = employeeRepository;

    public async Task<BaseResponse<PagedResult<EmployeeResponse>>> GetAllAsync(ApiQuerySpec query)
    {
        var pagedEmployees = await _employeeRepository.GetAllAsync(query);

        // Mapeamos los items
        var responseItems = pagedEmployees.Items
            .Select(e => e.ToResponse(query)) // ¡Tu mapper inteligente decide si incluye contratos!
            .ToList();

        // Construimos el resultado paginado de respuesta
        var pagedResponse = new PagedResult<EmployeeResponse>
        {
            Items = responseItems,
            TotalItems = pagedEmployees.TotalItems,
            Page = pagedEmployees.Page,
            PerPage = pagedEmployees.PerPage
        };

        return new BaseResponse<PagedResult<EmployeeResponse>>
        {
            IsSuccess = true,
            Message = "Employees retrieved successfully",
            StatusCode = 200,
            Data = pagedResponse
        };
    }

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

        var response = employee.ToResponse();
        return new BaseResponse<EmployeeResponse>
        {
            IsSuccess = true,
            Message = "Employee created successfully",
            StatusCode = 201,
            Data = response
        };
    }

    public async Task<BaseResponse<EmployeeResponse>> GetEmployee(int employeeId, ApiQuerySpec query)
    {
        Employee? employee = await _employeeRepository.GetEmployee(employeeId, query);
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
        var response = employee.ToResponse(query);
        return new BaseResponse<EmployeeResponse>
        {
            IsSuccess = true,
            Message = "Employee retrieved successfully.",
            StatusCode = 200,
            Data = response
        };
    }
}
