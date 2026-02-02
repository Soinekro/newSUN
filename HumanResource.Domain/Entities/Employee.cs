using CommonClass.Domain.Entities;

namespace HumanResource.Domain.Entities;
public class Employee : BaseAuditableClass
{
    public int EmployeeId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public ICollection<Contract> Contracts { get; set; } = [];
}
