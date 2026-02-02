using CommonClass.Aplication.Interfaces;
using HumanResource.Aplication.DTOs.Request;
using HumanResource.Aplication.DTOs.Responses;
using HumanResource.Domain.Entities;

namespace HumanResource.Aplication.Interfaces
{
    public interface IEmployeeService : IBaseService<Employee, EmployeeResponse, EmployeeRequest, EmployeeRequest> { }
}
