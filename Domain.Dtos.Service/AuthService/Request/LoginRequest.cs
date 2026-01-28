using System.ComponentModel.DataAnnotations;

namespace AuthService.Request
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "El usuario es obligatorio.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El usuario debe tener entre 3 y 50 caracteres.")]
        public string Username  { get; set; } = string.Empty;
        [Required(ErrorMessage = "La contraseña es obligatorio.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "la contraseña debe tener mas de 6 caracteres.")]
        public string Password { get; set; } = string.Empty;
    }
}
