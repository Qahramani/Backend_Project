using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Pustok.BLL.Helpers.Contracts;
using Pustok.BLL.Services.Abstraction;
using Pustok.BLL.Services.Implementation.Generic;
using Pustok.DAL.Repositories.Abstraction;
using Pustok.DAL.Repositories.Abstraction.Generic;

namespace Pustok.BLL.Services.Implementation;

public class CategoryManager : CrudManager<Category, CategoryViewModel, CategoryListViewModel, CategoryCreateViewModel, CategoryUpdateViewModel>, ICategoryService
{
    private readonly IWebHostEnvironment _webhosEnvironment;
    private readonly ICategoryRepository _categoryRepository;
    private readonly ICloudinaryService _cloudinaryService;

    public CategoryManager(IWebHostEnvironment webhosEnvironment, IRepository<Category> repository, IMapper mapper, ICategoryRepository categoryRepository, ICloudinaryService cloudinaryService) : base(repository, mapper)
    {
        _webhosEnvironment = webhosEnvironment;
        _categoryRepository = categoryRepository;
        _cloudinaryService = cloudinaryService;
    }
    public override async Task<CategoryViewModel> CreateAsync(CategoryCreateViewModel createViewModel)
    {
        createViewModel.ImageUrl = await _cloudinaryService.ImageCreateAsync(createViewModel.ImageFile);

        return await base.CreateAsync(createViewModel);
    }

    public async Task<List<CategoryViewModel>> GetParentCategories()
    {
        var list = await _categoryRepository.GetAllAsync(x => x.ParentCategoryId == null);

        var selectListItems = new List<SelectListItem>();

        foreach (var item in list)
        {
            selectListItems.Add(new SelectListItem
            {
                Text = item.Name,
                Value = item.Id.ToString()
            });
        }

        return _mapper.Map<List<CategoryViewModel>>(list);
    }

    public async Task<List<CategoryViewModel>> GetSubCategories(int id)
    {
        var list = await _categoryRepository.GetAllAsync(x => x.ParentCategoryId == id, enableTracking : false);

        return _mapper.Map<List<CategoryViewModel>>(list);
    }

    public override async Task<CategoryViewModel> UpdateAsync(CategoryUpdateViewModel updateViewModel)
    {
        var foundCategory = await _categoryRepository.GetAsync(updateViewModel.Id);

        if (foundCategory == null) throw new Exception("Category not found");

        if (updateViewModel.ImageFile != null)
        {
            foundCategory.ImageUrl = await _cloudinaryService.ImageCreateAsync(updateViewModel.ImageFile);
        }

        foundCategory = _mapper.Map(updateViewModel, foundCategory);

        var updatedVm = await _categoryRepository.UpdateAsync(foundCategory);

        return _mapper.Map<CategoryViewModel>(updatedVm);
    }


    public override async Task<CategoryViewModel> RemoveAsync(int id)
    {
        var category = await _categoryRepository.GetAsync(id, enableTracking : false);


        var subCategories = await GetSubCategories(id);

        if (subCategories != null)
        {

            var subCatVms = _mapper.Map<List<Category>>(subCategories);

            foreach (var subCategory in subCatVms)
            {
                await _categoryRepository.RemoveAsync(subCategory);

                await _cloudinaryService.FileDeleteAsync(subCategory.ImageUrl);
            }

        }
        await _cloudinaryService.FileDeleteAsync(category.ImageUrl);

        var deletedCategory = await _categoryRepository.RemoveAsync(category);

        return _mapper.Map<CategoryViewModel>(deletedCategory);
    }

    //public async Task<CategoryViewModel> RemoveAndNullifyChildrenAsync(int id)
    //{

    //    var category = await _categoryRepository.GetAsync(id);

    //    await _cloudinaryService.FileDeleteAsync(category.ImageUrl);

    //    var subCategories = await GetSubCategories(id);

    //    if (subCategories != null)
    //    {

    //        var subCatVms = _mapper.Map<List<Category>>(subCategories);

    //        foreach (var subCategory in subCatVms)
    //        {
    //            subCategory.ParentCategoryId = null;

    //            await _categoryRepository.UpdateAsync(subCategory);
    //        }

    //    }

    //    var deletedCategory = await _categoryRepository.RemoveAsync(category);

    //    return _mapper.Map<CategoryViewModel>(deletedCategory);
    //}

 
}
