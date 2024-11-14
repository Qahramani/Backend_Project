using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Pustok.BLL.Helpers.Contracts;
using Pustok.BLL.Services.Abstraction;
using Pustok.BLL.Services.Implementation.Generic;
using Pustok.DAL.Repositories.Abstraction;
using Pustok.DAL.Repositories.Abstraction.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;

namespace Pustok.BLL.Services.Implementation;

public class ProductManager : CrudManager<Product, ProductViewModel, ProductListViewModel, ProductCreateViewModel, ProductUpdateViewModel>, IProductService
{
    private readonly ICategoryService _categoryService;
    private readonly ITagService _tagService;
    private readonly ICloudinaryService _cloudinaryService;
    private readonly IProductRepository _productRepository;
    private readonly IProductTagService _productTagService;
    public ProductManager(IRepository<Product> repository, IMapper mapper, ICategoryService categoryService, ITagService tagService, ICloudinaryService cloudinaryService, IProductRepository productService, IProductRepository productRepository, IProductTagService productTagService) : base(repository, mapper)
    {
        _categoryService = categoryService;
        _tagService = tagService;
        _cloudinaryService = cloudinaryService;
        _productRepository = productRepository;
        _productTagService = productTagService;
    }

    public async Task<ProductCreateViewModel> GetProductCreateViewModelAsync()
    {
        var categories = await _categoryService.GetAllAsync();
        var tags = await _tagService.GetAllAsync(include: x => x.Include(x => x.ProductTags));

        ProductCreateViewModel vm = new()
        {
            Categories = categories,
            Tags = tags.Select(tag => new SelectListItem
            {
                Text = tag.Link,
                Value = tag.Id.ToString()
            }).ToList()
        };

        return vm;
    }

    public async Task<ProductUpdateViewModel> GetProductUpdateViewModelAsync(int id)
    {
        var categories = await _categoryService.GetAllAsync();

        var product = await _productRepository.GetAsync(x => x.Id == id, x => x.Include(x => x.Images).Include(x => x.ProductTags).ThenInclude(x => x.Tag!));

        var tags = await _tagService.GetAllAsync();
        var tagsSelectListItem = new List<SelectListItem>();

        foreach (var tag in tags)
        {
            tagsSelectListItem.Add(new SelectListItem
            {
                Text = tag.Link,
                Value = tag.Id.ToString()
            });

        }
        var updateViewModel = _mapper.Map<ProductUpdateViewModel>(product);
        updateViewModel.AllProductTags = tagsSelectListItem;
        updateViewModel.Categories = categories;
        updateViewModel.SelectedTagsIds = product!.ProductTags.Select(pt => pt.TagId).ToList();

        return updateViewModel;
    }

    public override async Task<ProductViewModel> UpdateAsync(ProductUpdateViewModel updateViewModel)
    {
        var oldTagsVm = await _productTagService.GetAllAsync(x => x.ProductId == updateViewModel.Id);

        //burda producta aid olan butun taglari pozdum
        foreach (var prodTag in oldTagsVm)
        {
            var foundTagVm = await _productTagService.GetAsync(prodTag.Id);
            if (foundTagVm == null) continue;

            await _productTagService.RemoveAsync(foundTagVm.Id);
        }
        //hamisin tezeden elave edirik (In Sa Allah isleyer)
        foreach (var tagId in updateViewModel.SelectedTagsIds)
        {
            var newTag = new ProductTagCreateViewModel
            {
                TagId = tagId,
                ProductId = updateViewModel.Id
            };
            await _productTagService.CreateAsync(newTag);
        }

        return await base.UpdateAsync(updateViewModel);
    }

    public async Task<ProductViewModel> GetProductDetailsViewModel(int id)
    {
        var product = await _productRepository.GetAsync(x => x.Id == id, include: x => x.Include(x => x.Category!).Include(x => x.Images).Include(x => x.ProductTags).ThenInclude(x => x.Tag!));

        if (product == null) throw new Exception("Product is not found");

        var vm = _mapper.Map<ProductViewModel>(product);

        return vm;
    }


    public override async Task<ProductViewModel> CreateAsync(ProductCreateViewModel createViewModel)
    {
        if (createViewModel.StockQuantity > 0)
            createViewModel.InStock = true;

        var product = _mapper.Map<Product>(createViewModel);


        //main image
        var mainImagePath = await _cloudinaryService.ImageCreateAsync(createViewModel.MainFile);

        ProductImage mainImage = new()
        {
            ImageUrl = mainImagePath,
            IsMain = true,
            Product = product
        };

        product.Images.Add(mainImage);

        //hover image
        var hoverImagePath = await _cloudinaryService.ImageCreateAsync(createViewModel.HoverFile);

        ProductImage hoverImage = new()
        {
            ImageUrl = mainImagePath,
            IsHover = true,
            Product = product
        };

        product.Images.Add(hoverImage);

        //additional images
        foreach (var image in createViewModel.AdditionalImages ?? new())
        {
            var additionalImagePath = await _cloudinaryService.ImageCreateAsync(image);

            ProductImage additionalImage = new()
            {
                ImageUrl = additionalImagePath,
                Product = product
            };
            product.Images.Add(additionalImage);
        }
        //adding tag
        foreach (var tagId in createViewModel.SelectedTagIds)
        {
            ProductTag productTag = new()
            {
                TagId = tagId,
                Product = product
            };
            product.ProductTags.Add(productTag);
        }

        await _productRepository.CreateAsync(product);


        return _mapper.Map<ProductViewModel>(product);
    }

    public async Task ProductSoftDeleteAsync(int id)
    {
        var product = await _productRepository.GetAsync(id);

        if (product == null) throw new Exception("Product not found");

        product.IsDeleted = true;

        await _productRepository.UpdateAsync(product);
    }
}
