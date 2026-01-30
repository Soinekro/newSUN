using HumanResource.Aplication.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HumanResource.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContractController(IContractService employeeService) : ControllerBase
    {
        private readonly IContractService _contractService = employeeService;

        [HttpPost("create")]
        [Authorize]
        public async Task<IActionResult> CreateContract([FromBody] Aplication.DTOs.Request.ContractRequest request)
        {
            var response = await _contractService.CreateAsync(request);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}
