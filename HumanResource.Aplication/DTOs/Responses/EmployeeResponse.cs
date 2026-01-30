namespace HumanResource.Aplication.DTOs.Responses;

public class EmployeeResponse
{
    public int EmployeeId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;

    public ICollection<ContractResponse>? Contracts { get; set; } = null;
}
