using CommonClass.Aplication.Services;
using CommonClass.Aplication.Specs;
using HumanResource.Aplication.DTOs.Mappers;
using HumanResource.Aplication.DTOs.Request;
using HumanResource.Aplication.DTOs.Responses;
using HumanResource.Aplication.Interfaces;
using HumanResource.Domain.Entities;
using HumanResource.Domain.Interfaces;

namespace HumanResource.Aplication.Services;

public class EmployeeService(IEmployeeRepository repository)
    : BaseService<Employee, EmployeeResponse, EmployeeRequest, EmployeeRequest>(repository), IEmployeeService
{
    protected override EmployeeResponse MapToResponse(Employee entity)
    {
        // Igual que en Contract: si Contracts viene cargado (por el include), el mapper los usa.
        return entity.ToResponseWithContracts();
    }

    protected override Employee MapToEntity(EmployeeRequest request)
        => new()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            DateOfBirth = request.DateOfBirth,
            PhoneNumber = request.Phone
        };

    protected override void MapToEntity(EmployeeRequest request, Employee entity, ApiQuerySpec query)
    {
        entity.FirstName = request.FirstName;
        entity.LastName = request.LastName;
        entity.Email = request.Email;
        entity.DateOfBirth = request.DateOfBirth;
        entity.PhoneNumber = request.Phone;
    }
}