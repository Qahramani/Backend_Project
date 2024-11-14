
using Microsoft.EntityFrameworkCore.Query;
using Pustok.BLL.ViewModels;
using Pustok.DAL.Paging;
using Pustok.DAL.Repositories.Abstraction.Generic;
using System.Linq.Expressions;

namespace Pustok.BLL.Services.Implementation.Generic;

public class CrudManager<TEntity, TViewModel, TListViewModel, TCreateViewModel, TUpdateViewModel> : ICrudService<TEntity, TViewModel, TListViewModel, TCreateViewModel, TUpdateViewModel>
    where TEntity : BaseEntity
    where TViewModel : IViewModel
    where TCreateViewModel : IViewModel
    where TUpdateViewModel : IViewModel
{
    private readonly IRepository<TEntity> _repository;
    protected readonly IMapper _mapper;

    public CrudManager(IRepository<TEntity> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public virtual async Task<TViewModel?> GetAsync(int id)
    {
        var entity = await _repository.GetAsync(id);

        var viewModel = _mapper.Map<TViewModel>(entity);

        return viewModel;
    }

    public virtual async Task<TViewModel?> GetAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null)
    {
        var entity = await _repository.GetAsync(predicate, include, orderBy);

        var viewModel = _mapper.Map<TViewModel>(entity);

        return viewModel;
    }
    public virtual async Task<TListViewModel> GetPagesAsync(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, int index = 0, int size = 10, bool enableTracking = true)
    {
        var entityList = await _repository.GetPagesAsync(predicate, orderBy, include, index, size, enableTracking);

        var viewModelList = _mapper.Map<TListViewModel>(entityList);

        return viewModelList;
    }

    public virtual async Task<TViewModel> CreateAsync(TCreateViewModel createViewModel)
    {
        var entity = _mapper.Map<TEntity>(createViewModel);

        var createdEntity = await _repository.CreateAsync(entity);

        var viewModel = _mapper.Map<TViewModel>(createdEntity);

        return viewModel;
    }

    public virtual async Task<TViewModel> UpdateAsync(TUpdateViewModel updateViewModel)
    {
        var entity = _mapper.Map<TEntity>(updateViewModel);

        var updatedEntity = await _repository.UpdateAsync(entity);

        var viewModel = _mapper.Map<TViewModel>(updatedEntity);

        return viewModel;
    }

    public virtual async Task<TViewModel> RemoveAsync(int id)
    {
        var entity = await _repository.GetAsync(id);

        if (entity == null) throw new Exception("Not found");

        var deletedEntity = await _repository.RemoveAsync(entity);

        var viewModel = _mapper.Map<TViewModel>(deletedEntity);

        return viewModel;
    }

    public virtual async Task<List<TViewModel>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null)
    {
        var list = await _repository.GetAllAsync(predicate, include, orderBy);

        if (list == null) throw new Exception("Not found");

        var viewModelList = _mapper.Map<List<TViewModel>>(list);

        return viewModelList;
    }
}
