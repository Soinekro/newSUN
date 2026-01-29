namespace HumanResource.Aplication.DTOs.Responses;

public class EmployeeResponse
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;

    public ContractResponse Contract { get; set; } = new ContractResponse();
}
