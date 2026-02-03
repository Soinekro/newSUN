using CommonClass.Application.Services;
using CommonClass.Application.Specs;
using ReceptionFresh.Application.DTOs.Mappers;
using ReceptionFresh.Application.DTOs.Request;
using ReceptionFresh.Application.DTOs.Responses;
using ReceptionFresh.Application.Interfaces;
using ReceptionFresh.Domain.Entities;
using ReceptionFresh.Domain.Interfaces;

namespace ReceptionFresh.Application.Services;

public class PalletService(IPalletRepository repository) 
    : BaseService<Pallet, PalletResponse, PalletRequest, PalletRequest>(repository), IPalletService
{
    protected override PalletResponse MapToResponse(Pallet entity)
        => entity.ToResponse();

    protected override Pallet MapToEntity(PalletRequest request)
        => new() 
        { 
            // TODO: Mapear propiedades de creación
        };

    protected override void MapToEntity(PalletRequest request, Pallet entity, ApiQuerySpec query)
    {
        // TODO: Mapear propiedades de actualización
    }
}