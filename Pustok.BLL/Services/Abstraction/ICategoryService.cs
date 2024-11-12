﻿namespace Pustok.BLL.Services.Abstraction;

public interface ICategoryService : ICrudService<Category, CategoryViewModel, CategoryListViewModel, CategoryPostViewModel, CategoryUpdateViewModel>
{
    Task<List<CategoryViewModel>> GetParentCategories();
    Task<List<CategoryViewModel>> GetSubCategories(int id);
}