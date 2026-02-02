using __Module__.Aplication.DTOs.Responses;
using __Module__.Domain.Entities;

namespace __Module__.Aplication.DTOs.Mappers;

public static class __Entity__ResponseMapper
{
    public static __Entity__Response ToResponse(this __Entity__ entity)
        => new()
        {
            // Id = entity.Id
        };
}