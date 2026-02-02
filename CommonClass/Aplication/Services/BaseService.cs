using CommonClass.Aplication.Interfaces;
using CommonClass.Aplication.Specs;
using CommonClass.Domain.Entities;
using CommonClass.Domain.Interfaces;
using CommonClass.Domain.Wrappers;

namespace CommonClass.Aplication.Services;

public abstract class BaseService<TEntity, TResponse, TCreateRequest, TUpdateRequest>(
    IBaseRepository<TEntity> repository
) : IBaseService<TEntity, TResponse, TCreateRequest, TUpdateRequest>
    where TEntity : BaseAuditableClass
    where TResponse : class
{
    protected readonly IBaseRepository<TEntity> _repository = repository;

    // Métodos abstractos que el hijo debe implementar para mapear
    protected abstract TResponse MapToResponse(TEntity entity);
    protected abstract TEntity MapToEntity(TCreateRequest request);
    protected abstract void MapToEntity(TUpdateRequest request, TEntity entity, ApiQuerySpec query);

    public virtual async Task<BaseResponse<PagedResult<TResponse>>> GetAllAsync(ApiQuerySpec query)
    {
        var result = await _repository.GetAllAsync(query);
        var responseItems = result.Items.Select(MapToResponse).ToList();

        var pagedResponse = new PagedResult<TResponse>
        {
            Items = responseItems,
            TotalItems = result.TotalItems,
            Page = result.Page,
            PerPage = result.PerPage
        };

        return new BaseResponse<PagedResult<TResponse>>(pagedResponse);
    }

    public virtual async Task<BaseResponse<TResponse>> GetByIdAsync(int id, ApiQuerySpec query)
    {
        var entity = await _repository.GetByIdAsync(id, query);
        if (entity == null)
            return new BaseResponse<TResponse>(false, "Not found", statusCode: 404);

        return new BaseResponse<TResponse>(MapToResponse(entity));
    }

    public virtual async Task<BaseResponse<TResponse>> CreateAsync(TCreateRequest request)
    {
        var entity = MapToEntity(request);
        await _repository.AddAsync(entity);
        return new BaseResponse<TResponse>(MapToResponse(entity))
        {
            StatusCode = 201,
            Message = "Created successfully"
        };
    }

    public virtual async Task<BaseResponse<TResponse>> UpdateAsync(int id, TUpdateRequest request, ApiQuerySpec query)
    {
        var entity = await _repository.GetByIdAsync(id, query);
        if (entity == null)
            return new BaseResponse<TResponse>(false, "Not found", statusCode: 404);

        MapToEntity(request, entity, query);
        await _repository.UpdateAsync(entity);

        return new BaseResponse<TResponse>(MapToResponse(entity));
    }

    public virtual async Task<BaseResponse<bool>> DeleteAsync(int id)
    {
        var deleted = await _repository.SoftDeleteAsync(id);
        if (!deleted)
            return new BaseResponse<bool>(false, "Not found", statusCode: 404);

        return new BaseResponse<bool>(true, "Deleted successfully");
    }
}