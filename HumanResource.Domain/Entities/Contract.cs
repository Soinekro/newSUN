using CommonClass.Domain.Entities;

namespace HumanResource.Domain.Entities;
public class Contract : BaseAuditableClass
{
    public int CtrId { get; set; }
    public int EmployeeId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Position { get; set; } = string.Empty;
    public decimal Salary { get; set; }

    public Employee Employee { get; set; } = null!;
}
