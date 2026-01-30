using CommonClass.Querying;
using HumanResource.Aplication.DTOs.Responses;
using HumanResource.Domain.Entities;

namespace HumanResource.Aplication.DTOs.Mappers;

public static class ContractResponseMapper
{
    public static ContractResponse ToResponse(this Contract contract)
    => new()
    {
        CtrId = contract.CtrId,
        StartDate = contract.StartDate,
        EndDate = contract.EndDate
    };

    public static ContractResponse ToResponseWithEmployee(this Contract contract)
    {
        var response = contract.ToResponse();
        response.Employee = contract.Employee?.ToResponse();
        return response;
    }

    public static ContractResponse ToResponse(this Contract contract, ApiQuerySpec query)
    {
        var includeEmployee = query.Relations?.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                                 .Contains("employee", StringComparer.OrdinalIgnoreCase) == true;

        if (includeEmployee)
        {
            // Usamos tu método existente que mapea ambos
            return contract.ToResponseWithEmployee();
        }

        // Si no lo pidieron, retornamos solo datos básicos
        return contract.ToResponse();
    }

}
