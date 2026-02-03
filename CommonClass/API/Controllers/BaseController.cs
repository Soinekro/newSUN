using CommonClass.Application.Interfaces;
using CommonClass.Application.Specs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CommonClass.API.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public abstract class BaseController<TEntity, TResponse, TCreateRequest, TUpdateRequest>(
    IBaseService<TEntity, TResponse, TCreateRequest, TUpdateRequest> service
) : ControllerBase
{
    protected readonly IBaseService<TEntity, TResponse, TCreateRequest, TUpdateRequest> _service = service;

    [HttpGet]
    public virtual async Task<IActionResult> GetAll([FromQuery] ApiQuerySpec query)
    {
        var response = await _service.GetAllAsync(query);
        return Ok(response);
    }

    [HttpGet("{id:int}")]
    public virtual async Task<IActionResult> GetById(int id, [FromQuery] ApiQuerySpec query)
    {
        var response = await _service.GetByIdAsync(id, query);
        if (!response.IsSuccess) return NotFound(response);
        return Ok(response);
    }

    [HttpPost]
    public virtual async Task<IActionResult> Create([FromBody] TCreateRequest request)
    {
        // Validación básica si usas DataAnnotations
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var response = await _service.CreateAsync(request);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPut("{id:int}")]
    public virtual async Task<IActionResult> Update(int id, [FromBody] TUpdateRequest request, [FromQuery] ApiQuerySpec query)
    {
        var response = await _service.UpdateAsync(id, request, query);
        if (!response.IsSuccess) return NotFound(response);
        return Ok(response);
    }

    [HttpDelete("{id:int}")]
    public virtual async Task<IActionResult> Delete(int id)
    {
        var response = await _service.DeleteAsync(id);
        if (!response.IsSuccess) return NotFound(response);
        return Ok(response);
    }
}