namespace RRHHService.API.WebAPI.DTOs
{
    public class UserAuthenticationRequest
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
