using CommonClass.Querying;
using HumanResource.Aplication.DTOs.Responses;
using HumanResource.Domain.Entities;

namespace HumanResource.Aplication.DTOs.Mappers;

public static class EmployeeResponseMapper
{
    public static EmployeeResponse ToResponse(this Employee employee)
        => new()
        {
            EmployeeId = employee.EmployeeId,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Email = employee.Email,
            PhoneNumber = employee.PhoneNumber
        };

    public static EmployeeResponse ToResponseWithContracts(this Employee employee)
    {
        var response = employee.ToResponse();
        response.Contracts = employee.Contracts?.Select(c => c.ToResponse()).ToList() ?? [];
        return response;
    }

    public static EmployeeResponse ToResponse(this Employee employee, ApiQuerySpec query)
    {
        var includeContracts = query.Relations?.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
            .Contains("contracts", StringComparer.OrdinalIgnoreCase) == true;

        if (includeContracts)
        {
            return employee.ToResponseWithContracts();
        }
        return employee.ToResponse();
    }
}
