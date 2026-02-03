using CommonClass.Application.Specs;
using CommonClass.Domain.Entities;
using CommonClass.Domain.Wrappers;

namespace CommonClass.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : BaseAuditableClass
    {
        Task<PagedResult<T>> GetAllAsync(ApiQuerySpec query);
        Task<T?> GetByIdAsync(int id, ApiQuerySpec query);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task<bool> SoftDeleteAsync(int id);
    }
}
