using CommonClass.Aplication.Services;
using CommonClass.Aplication.Specs;
using HumanResource.Aplication.DTOs.Mappers;
using HumanResource.Aplication.DTOs.Request;
using HumanResource.Aplication.DTOs.Responses;
using HumanResource.Domain.Entities;

namespace HumanResource.Aplication.Services;

public class ContractService(Domain.Interfaces.IContractRepository repository)
    : BaseService<Contract, ContractResponse, ContractRequest, ContractRequest>(repository), Interfaces.IContractService
{
    // Usamos el query actual para decidir el mapeo (Employee anidado o no)
    // PERO: BaseService no pasa 'query' a MapToResponse por defecto.
    // Si necesitas 'relations' en el mapeo, sobreescribe GetAllAsync o ajusta la base.
    // Opción simple: Mapeamos siempre "básico" y si hay includes, EF los trae y el mapper los usa.

    protected override ContractResponse MapToResponse(Contract entity)
    {
        return entity.ToResponseWithEmployee();
    }

    protected override Contract MapToEntity(ContractRequest request)
        => new()
        {
            EmployeeId = request.EmployeeId,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            Position = request.Position,
            Salary = request.Salary
        };

    protected override void MapToEntity(ContractRequest request, Contract entity, ApiQuerySpec query)
    {
        // Lógica de actualización (PUT)
        entity.EmployeeId = request.EmployeeId;
        entity.StartDate = request.StartDate;
        entity.EndDate = request.EndDate;
        entity.Position = request.Position;
        entity.Salary = request.Salary;
    }
}