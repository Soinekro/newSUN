using CommonClass.Validates;
using System.ComponentModel.DataAnnotations;

namespace HumanResource.Aplication.DTOs.Request;
public class EmployeeRequest
{
    public int? EmployeeId { get; set; }

    [Display(Name = "Nombres")]
    [RequiredEx]
    public string FirstName { get; set; } = string.Empty;

    [Display(Name = "Apellidos")]
    [RequiredEx]
    public string LastName { get; set; } = string.Empty;

    [Display(Name = "Correo electronico")]
    [RequiredEx]
    public string Email { get; set; } = string.Empty;

    [Display(Name = "numero de celular")]
    [RequiredEx]
    public string Phone { get; set; } = string.Empty;

    [Display(Name = "Fecha de nacimiento")]
    [RequiredEx]
    public DateTime DateOfBirth { get; set; }

}
