using CommonClass.Aplication.Services;
using CommonClass.Aplication.Specs;
using HumanResource.Aplication.DTOs.Mappers;
using HumanResource.Aplication.DTOs.Request;
using HumanResource.Aplication.DTOs.Responses;
using HumanResource.Aplication.Interfaces;
using HumanResource.Domain.Entities;
using HumanResource.Domain.Interfaces;

namespace HumanResource.Aplication.Services;

public class AttendanceService(IAttendanceRepository repository) 
    : BaseService<Attendance, AttendanceResponse, AttendanceRequest, AttendanceRequest>(repository), IAttendanceService
{
    protected override AttendanceResponse MapToResponse(Attendance entity)
        => entity.ToResponse();

    protected override Attendance MapToEntity(AttendanceRequest request)
        => new() 
        { 
            // TODO: Mapear propiedades de creación
        };

    protected override void MapToEntity(AttendanceRequest request, Attendance entity, ApiQuerySpec query)
    {
        // TODO: Mapear propiedades de actualización
    }
}