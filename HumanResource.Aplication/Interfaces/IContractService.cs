using CommonClass.Querying;
using CommonClass.Response;
using HumanResource.Aplication.DTOs.Request;
using HumanResource.Aplication.DTOs.Responses;

namespace HumanResource.Aplication.Interfaces
{
    public partial interface IContractService
    {
        Task<BaseResponse<ContractResponse>> CreateAsync(ContractRequest request);
        Task<BaseResponse<ContractResponse>> GetContract(int contractId, ApiQuerySpec query);
    }
}
