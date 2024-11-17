using Microsoft.EntityFrameworkCore.Query;
using Pustok.DAL.DataContext;
using Pustok.DAL.Paging;
using System.Linq;
using System.Linq.Expressions;

namespace Pustok.DAL.Repositories.Implementation.Generic;

public class EfCoreRepository<T> : IRepository<T> where T : BaseEntity
{
    private readonly AppDbContext _dbContext;

    public EfCoreRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public virtual async Task<T?> GetAsync(int id, bool enableTracking = true)
    {

        var result = await _dbContext.Set<T>().FindAsync(id);

        return result;
    }

    public virtual async Task<T?> GetAsync(Expression<Func<T, bool>> predicate,
                                                 Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
                                                 Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null , bool enableTracking = true)

    {
        IQueryable<T> query = _dbContext.Set<T>();

        if (include != null) query = include(query);

        if (orderBy != null) query = orderBy(query);

        query = query.Where(predicate);

        return await query.FirstOrDefaultAsync();
    }

    public virtual async Task<Paginate<T>> GetPagesAsync(Expression<Func<T, bool>>? predicate = null,
                                                     Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                                                     Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
                                                     int index = 0, int size = 10, bool enableTracking = true)
    {
        IQueryable<T> queryable = _dbContext.Set<T>();

        if (!enableTracking) queryable = queryable.AsNoTracking();

        if (include != null) queryable = include(queryable);

        if (predicate != null) queryable = queryable.Where(predicate);

        if (orderBy != null) queryable = orderBy(queryable);

        return await queryable.ToPaginateAsync(index, size);
    }

    public virtual async Task<T> CreateAsync(T entity)
    {
        var entityEntry = await _dbContext.Set<T>().AddAsync(entity);

        await _dbContext.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public virtual async Task<T> RemoveAsync(T entity)
    {
        var entityEntry = _dbContext.Set<T>().Remove(entity);

        await _dbContext.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public virtual async Task<T> UpdateAsync(T entity)
    {
        var entityEntry = _dbContext.Set<T>().Update(entity);

        await _dbContext.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool enableTracking = true)
    {

        IQueryable<T> query = _dbContext.Set<T>();

        if (!enableTracking) query = query.AsNoTracking();

        if (include != null) query = include(query);

        if (orderBy != null) query = orderBy(query);
        
        if(predicate != null) query = query.Where(predicate);

        return await query.ToListAsync();
    }
}
