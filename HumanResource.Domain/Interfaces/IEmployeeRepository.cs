
using CommonClass.Querying;
using CommonClass.Response;
using HumanResource.Domain.Entities;

namespace HumanResource.Domain.Interfaces;
public interface IEmployeeRepository
{
    Task<PagedResult<Employee>> GetAllAsync(ApiQuerySpec query);
    Task<Employee> CreateAsync(Employee contract);
    Task<Employee?> GetEmployee(int employeeId, ApiQuerySpec query);
}
