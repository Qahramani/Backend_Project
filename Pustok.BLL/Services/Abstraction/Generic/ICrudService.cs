using Microsoft.EntityFrameworkCore.Query;
using Pustok.DAL.DataContext.Entities.Common;
using Pustok.DAL.Paging;
using System.Linq.Expressions;

namespace Pustok.BLL.Services.Abstraction.Generic;

public interface ICrudService<TEntity,TViewModel,TListViewModel,TCreateViewModel,TUpdateViewModel>
    where TEntity : BaseEntity
    where TViewModel : IViewModel
    where TCreateViewModel : IViewModel
    where TUpdateViewModel : IViewModel
{
    Task<TViewModel?> GetAsync(int id);

    Task<TViewModel?> GetAsync(Expression<Func<TEntity, bool>> predicate,
                               Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
                               Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null);
    Task<List<TViewModel>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate = null,
                               Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
                               Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null);
    Task<TListViewModel> GetPagesAsync(Expression<Func<TEntity, bool>>? predicate = null,
                                       Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
                                       Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
                                       int index = 0, int size = 10, bool enableTracking = true);
    Task<TViewModel> CreateAsync(TCreateViewModel createViewModel);
    Task<TViewModel> UpdateAsync(TUpdateViewModel entity);
    Task<TViewModel> RemoveAsync(int id);
}
