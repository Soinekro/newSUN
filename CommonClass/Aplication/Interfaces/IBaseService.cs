using CommonClass.Aplication.Specs;
using CommonClass.Domain.Wrappers;

namespace CommonClass.Aplication.Interfaces;
public interface IBaseService<TEntity, TResponse, TCreateRequest, TUpdateRequest>
{
    Task<BaseResponse<PagedResult<TResponse>>> GetAllAsync(ApiQuerySpec query);
    Task<BaseResponse<TResponse>> GetByIdAsync(int id, ApiQuerySpec query);
    Task<BaseResponse<TResponse>> CreateAsync(TCreateRequest request);
    Task<BaseResponse<TResponse>> UpdateAsync(int id, TUpdateRequest request, ApiQuerySpec query);
    Task<BaseResponse<bool>> DeleteAsync(int id);
}
