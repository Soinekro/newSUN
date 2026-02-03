using CommonClass.Application.Services;
using CommonClass.Application.Specs;
using __Module__.Application.DTOs.Mappers;
using __Module__.Application.DTOs.Request;
using __Module__.Application.DTOs.Responses;
using __Module__.Application.Interfaces;
using __Module__.Domain.Entities;
using __Module__.Domain.Interfaces;

namespace __Module__.Application.Services;

public class __Entity__Service(I__Entity__Repository repository) 
    : BaseService<__Entity__, __Entity__Response, __Entity__Request, __Entity__Request>(repository), I__Entity__Service
{
    protected override __Entity__Response MapToResponse(__Entity__ entity)
        => entity.ToResponse();

    protected override __Entity__ MapToEntity(__Entity__Request request)
        => new() 
        { 
            // TODO: Mapear propiedades de creación
        };

    protected override void MapToEntity(__Entity__Request request, __Entity__ entity, ApiQuerySpec query)
    {
        // TODO: Mapear propiedades de actualización
    }
}