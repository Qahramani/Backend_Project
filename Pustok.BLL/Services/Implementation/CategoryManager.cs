using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Update.Internal;
using Pustok.BLL.Helpers;
using Pustok.BLL.Services.Abstraction;
using Pustok.BLL.Services.Implementation.Generic;
using Pustok.DAL.Repositories.Abstraction;
using Pustok.DAL.Repositories.Abstraction.Generic;

namespace Pustok.BLL.Services.Implementation;

public class CategoryManager : CrudManager<Category, CategoryViewModel, CategoryListViewModel, CategoryPostViewModel, CategoryUpdateViewModel>, ICategoryService
{
    private readonly string path = "";
    private readonly IWebHostEnvironment _webhosEnvironment;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryManager(IWebHostEnvironment webhosEnvironment, IRepository<Category> repository, IMapper mapper, ICategoryRepository categoryRepository) : base(repository, mapper)
    {
        _webhosEnvironment = webhosEnvironment;
        path = Path.Combine(_webhosEnvironment.WebRootPath, "image", "category");
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }
    public override async Task<CategoryViewModel> CreateAsync(CategoryPostViewModel createViewModel)
    {
        createViewModel.ImageUrl = await createViewModel.ImageFile.GenerateFileAsync(path);

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
        var list = await _categoryRepository.GetAllAsync(x => x.ParentCategoryId == id);

        return _mapper.Map<List<CategoryViewModel>>(list);
    }

    public override async Task<CategoryViewModel> UpdateAsync(CategoryUpdateViewModel updateViewModel)
    {
        var foundCategory = await _categoryRepository.GetAsync(updateViewModel.Id);

        if (foundCategory == null) throw new Exception("Category not found");

        if(updateViewModel.ImageFile != null)
        {
            foundCategory.ImageUrl.DeleteFile(path);

            foundCategory.ImageUrl = await updateViewModel.ImageFile.GenerateFileAsync(path);
        }

        foundCategory = _mapper.Map(updateViewModel,foundCategory);

       var updatedVm = await _categoryRepository.UpdateAsync(foundCategory);

        return _mapper.Map<CategoryViewModel>(updatedVm);
    }
}
