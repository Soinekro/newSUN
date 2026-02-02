using HumanResource.Aplication.DTOs.Responses;
using HumanResource.Domain.Entities;

namespace HumanResource.Aplication.DTOs.Mappers;

public static class AttendanceResponseMapper
{
    public static AttendanceResponse ToResponse(this Attendance entity)
        => new()
        {
            // Id = entity.Id
        };
}