using ReceptionFresh.Application.DTOs.Responses;
using ReceptionFresh.Domain.Entities;

namespace ReceptionFresh.Application.DTOs.Mappers;

public static class PalletResponseMapper
{
    public static PalletResponse ToResponse(this Pallet entity)
        => new()
        {
            // Id = entity.Id
        };
}