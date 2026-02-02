using CommonClass.API.Controllers;
using HumanResource.Aplication.DTOs.Request;
using HumanResource.Aplication.DTOs.Responses;
using HumanResource.Aplication.Interfaces;
using HumanResource.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HumanResource.API.Controllers;

[Route("api/[controller]")]
public class EmployeeController(IEmployeeService service)
    : BaseController<Employee, EmployeeResponse, EmployeeRequest, EmployeeRequest>(service)
{
}