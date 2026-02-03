using CommonClass.Application.Specs;
using CommonClass.Domain.Entities;
using CommonClass.Domain.Interfaces;
using CommonClass.Domain.Wrappers;
using CommonClass.Infrastructure.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CommonClass.Infrastructure.Persistence.Repositories;
/// <summary>
/// Implementación base genérica usando EF Core
/// </summary>
public abstract class BaseRepository<T, TContext>(TContext context) : IBaseRepository<T>
    where T : BaseAuditableClass
    where TContext : DbContext
{
    protected readonly TContext _context = context;
    protected readonly DbSet<T> _dbSet = context.Set<T>();

    // Diccionarios que cada hijo puede sobreescribir
    protected virtual Dictionary<string, Func<IQueryable<T>, IQueryable<T>>> AllowedIncludes => [];
    protected virtual Dictionary<string, Expression<Func<T, object?>>> AllowedSorts => [];
    protected virtual Dictionary<string, Expression<Func<T, bool>>> AllowedFilters => [];

    public virtual async Task<PagedResult<T>> GetAllAsync(ApiQuerySpec query)
    {
        IQueryable<T> q = _dbSet.AsNoTracking().Where(x => x.SecStatus); // Solo activos

        // Usando tus extensiones
        q = q.ApplyIncludes(query.Relations, AllowedIncludes);
        // q = q.ApplyFiltering(...) // Si decides implementar filtros genéricos
        q = q.ApplySort(query.Sort, AllowedSorts);

        var total = await q.CountAsync();

        // Aplica paginación (usando la extensión corregida)
        q = q.ApplyPagination(query.Page, query.PerPage);

        var items = await q.ToListAsync();

        return new PagedResult<T>
        {
            Items = items,
            TotalItems = total,
            Page = query.Page,
            PerPage = query.PerPage
        };
    }

    public virtual async Task<T?> GetByIdAsync(int id, ApiQuerySpec query)
    {
        // 1. Preparamos query base
        IQueryable<T> q = _dbSet;

        // 2. Aplicamos Includes (si los hay)
        q = q.ApplyIncludes(query.Relations, AllowedIncludes);

        // 3. Buscamos la definición de la Primary Key en el modelo de EF
        var keyName = _context.Model.FindEntityType(typeof(T))?
            .FindPrimaryKey()?.Properties
            .Select(x => x.Name)
            .FirstOrDefault();

        if (string.IsNullOrEmpty(keyName))
            throw new InvalidOperationException($"La entidad {typeof(T).Name} no tiene una Primary Key definida.");

        // 4. Ejecutamos la consulta filtrando por esa PK dinámica y SecStatus
        // Usamos EF.Property<int> para decirle a EF "el campo que se llame 'keyName' compáralo con 'id'"
        return await q
            .Where(e => EF.Property<int>(e, keyName) == id && e.SecStatus)
            .SingleOrDefaultAsync();
    }

    public virtual async Task<T> AddAsync(T entity)
    {
        entity.SecCreate = DateTime.UtcNow;
        entity.SecStatus = true;
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public virtual async Task UpdateAsync(T entity)
    {
        entity.SecUpdate = DateTime.UtcNow;
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }

    public virtual async Task<bool> SoftDeleteAsync(int id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity == null || !entity.SecStatus) return false;

        entity.SecStatus = false;
        entity.SecUpdate = DateTime.UtcNow;

        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
        return true;
    }
}