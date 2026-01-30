using CommonClass.Querying;
using CommonClass.Response;
using HumanResource.Domain.Entities;
using HumanResource.Domain.Interfaces;
using HumanResource.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;
using System.Linq.Expressions;

namespace HumanResource.Infrastructure.Repositories;
public class EmployeeRepository(HumanResourceDbContext context) : IEmployeeRepository
{
    private readonly HumanResourceDbContext _context = context;

    public async Task<PagedResult<Employee>> GetAllAsync(ApiQuerySpec query)
    {
        // 1. INCLUDES
        var allowedIncludes = new Dictionary<string, Func<IQueryable<Employee>, IQueryable<Employee>>>(StringComparer.OrdinalIgnoreCase)
        {
            ["contracts"] = q => q.Include(e => e.Contracts),
        };

        // 2. SORTS
        var allowedSorts = new Dictionary<string, Expression<Func<Employee, object?>>>(StringComparer.OrdinalIgnoreCase)
        {
            ["id"] = e => e.EmployeeId,
            ["firstname"] = e => e.FirstName,
            ["lastname"] = e => e.LastName,
            ["email"] = e => e.Email,
            ["dob"] = e => e.DateOfBirth
        };

        IQueryable<Employee> q = _context.Employees.AsNoTracking();

        // Aplicamos Relations
        q = q.ApplyIncludes(query.Relations, allowedIncludes);

        // Aplicamos Filtros (Manuales para mayor control)
        if (query.Filter is not null)
        {
            if (query.Filter.TryGetValue("firstName", out var firstName))
                q = q.Where(e => e.FirstName.Contains(firstName));

            if (query.Filter.TryGetValue("lastName", out var lastName))
                q = q.Where(e => e.LastName.Contains(lastName));

            if (query.Filter.TryGetValue("email", out var email))
                q = q.Where(e => e.Email.Contains(email));
        }

        // Aplicamos Sort
        q = q.ApplySort(query.Sort, allowedSorts);

        // 3. PAGINACIÓN
        // Primero contamos el total REAL antes de cortar
        var total = await q.CountAsync();

        q = q.ApplyPagination(query.Page, query.PerPage);

        var items = await q.ToListAsync();

        return new PagedResult<Employee>
        {
            Items = items,
            TotalItems = total,
            Page = query.Page,
            PerPage = query.PerPage,
        };
    }

    public async Task<Employee> CreateAsync(Employee employee)
    {
        _context.Employees.Add(employee);
        await _context.SaveChangesAsync();
        return employee;
    }

    public async Task<Employee?> GetEmployee(int employeeId, ApiQuerySpec query)
    {
        var allowedIncludes = new Dictionary<string, Func<IQueryable<Employee>, IQueryable<Employee>>>(StringComparer.OrdinalIgnoreCase)
        {
            ["Contracts"] = q => q.Include(e => e.Contracts)
        };
        IQueryable<Employee> employee = _context.Employees
            .AsNoTracking()
            .Where(c => c.EmployeeId == employeeId)
            .ApplyIncludes(query.Relations, allowedIncludes);

        return await employee.SingleOrDefaultAsync();
    }
}
