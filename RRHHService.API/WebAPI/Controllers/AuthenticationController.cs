using Microsoft.AspNetCore.Mvc;
using RRHHService.API.Application.Services;
using RRHHService.API.WebAPI.DTOs;

namespace RRHHService.API.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly AuthenticationService _authenticationService;

        public AuthenticationController(AuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] UserAuthenticationRequest request, [FromQuery] string connectionString)
        {
            var isAuthenticated = await _authenticationService.AuthenticateAsync(connectionString, request.Username, request.Password);

            if (isAuthenticated)
                return Ok(new { Message = "Authentication successful" });

            return Unauthorized(new { Message = "Invalid username or password" });
        }
    }
}
