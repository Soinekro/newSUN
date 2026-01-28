using Api.Common.Response;
using AuthService.Application.DTOs;
using AuthService.Application.Interfaces;
using AuthService.Domain.Entities;
using AuthService.Domain.Interfaces;

namespace AuthService.Application.Services;

/// <summary>
/// Implementación del servicio de autenticación.
/// Orquesta el flujo de inicio de sesión y registro utilizando el repositorio de usuarios y los servicios de seguridad.
/// </summary>
public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordService _passwordService;
    private readonly IJwtTokenService _jwtTokenService;

    public AuthService(IUserRepository userRepository, IPasswordService passwordService, IJwtTokenService jwtTokenService)
    {
        _userRepository = userRepository;
        _passwordService = passwordService;
        _jwtTokenService = jwtTokenService;
    }

    public async Task<BaseResponse<LoginResponse>> LoginAsync(LoginRequest request)
    {
        if (request == null)
            return new BaseResponse<LoginResponse>(false, "La solicitud no puede ser nula.");

        // 1. Buscar usuario
        var user = await _userRepository.GetByUsernameAsync(request.Username);
        if (user == null)
            return new BaseResponse<LoginResponse>(false, "Usuario o contraseña inválidos.");

        // 2. Verificar contraseña
        if (!_passwordService.VerifyPassword(request.Password, user.PasswordHash))
            return new BaseResponse<LoginResponse>(false, "Usuario o contraseña inválidos.");

        // 3. Generar token
        var token = _jwtTokenService.GenerateToken(user);

        // 4. Retornar éxito
        return new BaseResponse<LoginResponse>(new LoginResponse { AccessToken = token })
        {
            Message = "Autenticación exitosa."
        };
    }

    public async Task<BaseResponse<RegisterResponse>> RegisterAsync(RegisterRequest request)
    {
        if (request == null)
            return new BaseResponse<RegisterResponse>(false, "La solicitud no puede ser nula.");

        var username = request.Username.Trim();
        // Validar unicidad
        if (await _userRepository.ExistsByUsernameAsync(username))
            return new BaseResponse<RegisterResponse>(false, "El username ya está registrado.");

        // Hash fuerte
        var passwordHash = _passwordService.HashPassword(request.Password);

        var now = DateTime.UtcNow;
        var createdBy = request.CreatedByUserId ?? 0; // 0 = system (puedes cambiarlo luego)

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
