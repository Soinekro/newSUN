using AuthService.Application.DTOs;
using AuthService.Application.Interfaces;
using AuthService.Domain.Entities;
using AuthService.Domain.Interfaces;
using CommonClass.Domain.Wrappers;

namespace AuthService.Application.Services;

public class AuthService(IUserRepository userRepository, IPasswordService passwordService, IJwtTokenService jwtTokenService) : IAuthService
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IPasswordService _passwordService = passwordService;
    private readonly IJwtTokenService _jwtTokenService = jwtTokenService;

    public async Task<BaseResponse<LoginResponse>> LoginAsync(LoginRequest request)
    {
        // Para este servicio, asumimos que las validaciones de null/required ya las manejó el filtro global.
        const string invalidCredentialsMessage = "Usuario o contraseña inválidos.";

        var user = await _userRepository.GetByUsernameAsync(request.Username);
        if (user == null)
            return new BaseResponse<LoginResponse>(false, invalidCredentialsMessage);

        if (!_passwordService.VerifyPassword(request.Password, user.PasswordHash))
            return new BaseResponse<LoginResponse>(false, invalidCredentialsMessage);

        var token = _jwtTokenService.GenerateToken(user);

        return new BaseResponse<LoginResponse>(new LoginResponse { AccessToken = token })
        {
            Message = "Autenticación exitosa."
        };
    }

    public async Task<BaseResponse<RegisterResponse>> RegisterAsync(RegisterRequest request)
    {
        var username = request.Username.Trim();

        if (await _userRepository.ExistsByUsernameAsync(username))
            return new BaseResponse<RegisterResponse>(false, "El username ya está registrado.");

        var passwordHash = _passwordService.HashPassword(request.Password);
        var now = DateTime.UtcNow;
        var createdBy = request.CreatedByUserId ?? 0;

        var user = new User
        {
            Username = username,
            PasswordHash = passwordHash,
            SecUserId = createdBy,
            SecCreate = now,
            SecStatus = true
        };

        var created = await _userRepository.CreateAsync(user);

        return new BaseResponse<RegisterResponse>(new RegisterResponse
        {
            Id = created.Id,
            Username = created.Username
        })
        {
            Message = "Usuario registrado correctamente."
        };
    }
}