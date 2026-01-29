using HumanResource.Infrastructure.Persistence;
using HumanResource.Domain.Interfaces;
using HumanResource.Domain.Entities;

namespace HumanResource.Infrastructure.Repositories;
public class EmployeeRepository(HumanResourceDbContext context) : IEmployeeRepository
{
    private readonly HumanResourceDbContext _context = context;

    public async Task<Employee> CreateAsync(Employee employee)
    {
        _context.Employees.Add(employee);
        await _context.SaveChangesAsync();
        return employee;
    }
}
