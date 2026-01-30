using CommonClass.Querying;
using CommonClass.Response;
using HumanResource.Aplication.DTOs.Request;
using HumanResource.Aplication.DTOs.Responses;

namespace HumanResource.Aplication.Interfaces
{
    public partial interface IEmployeeService
    {
        Task<BaseResponse<PagedResult<EmployeeResponse>>> GetAllAsync(ApiQuerySpec query);
        Task<BaseResponse<EmployeeResponse>> CreateAsync(EmployeeRequest request);
        Task<BaseResponse<EmployeeResponse>> GetEmployee(int EmployeeId, ApiQuerySpec query);
    }
}
