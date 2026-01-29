using CommonClass.Validates;
using System.ComponentModel.DataAnnotations;

namespace HumanResource.Aplication.DTOs.Request;
public class ContractRequest
{
    public int? CtrId { get; set; }

    [Display(Name = "Empleado")]
    [RequiredEx]
    public int EmployeeId { get; set; }

    [Display(Name = "dia inicio")]
    [RequiredEx]
    public DateTime StartDate { get; set; }

    [Display(Name = "dia fin")]
    [RequiredEx]
    public DateTime EndDate { get; set; }

    [Display(Name = "cargo")]
    [RequiredEx]
    public string Position { get; set; } = string.Empty;

    [Display(Name = "salario")]
    [RequiredEx]
    public decimal Salary { get; set; }
}

