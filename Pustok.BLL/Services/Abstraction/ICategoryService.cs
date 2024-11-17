namespace Pustok.BLL.Services.Abstraction;


public interface ICategoryService : ICrudService<Category, CategoryViewModel, CategoryListViewModel, CategoryCreateViewModel, CategoryUpdateViewModel>
{
    Task<List<CategoryViewModel>> GetParentCategories();
    Task<List<CategoryViewModel>> GetSubCategories(int id);
    //Task<CategoryViewModel> RemoveAndNullifyChildrenAsync(int id); 

}
