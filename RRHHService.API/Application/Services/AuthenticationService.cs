using RRHHService.API.Infrastructure.Repositories;

namespace RRHHService.API.Application.Services
{
    public class AuthenticationService
    {
        private readonly UserRepository _userRepository;

        public AuthenticationService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> AuthenticateAsync(string connectionString, string username, string password)
        {
            return await _userRepository.AuthenticateUserAsync(connectionString, username, password);
        }
    }
}
