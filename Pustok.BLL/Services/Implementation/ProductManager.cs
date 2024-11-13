using Pustok.BLL.Services.Abstraction;
using Pustok.BLL.Services.Implementation.Generic;
using Pustok.DAL.Repositories.Abstraction.Generic;

namespace Pustok.BLL.Services.Implementation;

public class ProductManager : CrudManager<Product, ProductViewModel, ProductListViewModel, ProductCreateViewModel, ProductUpdateViewModel>,IProductService
{
    private readonly ICategoryService _categoryService;
    private readonly ITagService _tagService;
    public ProductManager(IRepository<Product> repository, IMapper mapper, ICategoryService categoryService, ITagService tagService) : base(repository, mapper)
    {
        _categoryService = categoryService;
        _tagService = tagService;
    }

    public async Task<ProductCreateViewModel> GetProductCreateViewModelAsync()
    {
        var categories = await _categoryService.GetAllAsync();
        var tags = await _tagService.GetAllAsync();

        ProductCreateViewModel vm = new()
        {
            Categories = categories,
            ProductTags = tags
        };

        return vm;
    }
}
