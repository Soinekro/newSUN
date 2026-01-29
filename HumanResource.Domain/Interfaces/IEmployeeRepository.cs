
using HumanResource.Domain.Entities;

namespace HumanResource.Domain.Interfaces;
public interface IEmployeeRepository
{
    Task<Employee> CreateAsync(Employee contract);
}
