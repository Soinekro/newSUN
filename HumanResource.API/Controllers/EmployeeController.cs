using CommonClass.Querying;
using HumanResource.Aplication.DTOs.Request;
using HumanResource.Aplication.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HumanResource.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController(IEmployeeService employeeService) : ControllerBase
{
    private readonly IEmployeeService _employeeService = employeeService;
    // GET: EmployeeController/Create

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] ApiQuerySpec query)
    {
        var response = await _employeeService.GetAllAsync(query);
        return Ok(response);
    }

    [HttpPost("create")]
    [Authorize]
    public async Task<IActionResult> CreateEmploye([FromBody, Required] EmployeeRequest request)
    {
        var response = await _employeeService.CreateAsync(request);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(response);

    }

    [HttpGet("{employeeId}")]
    [Authorize]
    public async Task<IActionResult> GetEmployee([FromRoute] int employeeId, [FromQuery] ApiQuerySpec query)
    {
        var response = await _employeeService.GetEmployee(employeeId, query);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(response);
    }

}
