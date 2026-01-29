namespace HumanResource.Aplication.DTOs.Responses;
public class ContractResponse
{
    public int CtrId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; } = DateTime.Now;

    public EmployeeResponse Employee { get; set; } = null!;
}