using CommonClass.Infrastructure.Persistence.Repositories;
using HumanResource.Domain.Entities;
using HumanResource.Domain.Interfaces;
using HumanResource.Infrastructure.Persistence; // Asume que aquí está el DbContext
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HumanResource.Infrastructure.Repositories;

public class AttendanceRepository(HumanResourceDbContext context) 
    : BaseRepository<Attendance, HumanResourceDbContext>(context), IAttendanceRepository
{
    protected override Dictionary<string, Func<IQueryable<Attendance>, IQueryable<Attendance>>> AllowedIncludes => new(StringComparer.OrdinalIgnoreCase)
    {
        // ["algo"] = q => q.Include(x => x.Algo)
    };
    
    // Configura sort por defecto si quieres
    protected override Dictionary<string, Expression<Func<Attendance, object?>>> AllowedSorts => new(StringComparer.OrdinalIgnoreCase)
    {
        // ["id"] = x => x.Id
    };
}