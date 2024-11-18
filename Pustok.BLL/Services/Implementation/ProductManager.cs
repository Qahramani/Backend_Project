using Microsoft.EntityFrameworkCore;
using Pustok.BLL.Exceptions;
using Pustok.BLL.Helpers.Contracts;
using Pustok.BLL.Services.Abstraction;
using Pustok.BLL.Services.Implementation.Generic;
using Pustok.DAL.Repositories.Abstraction;
using Pustok.DAL.Repositories.Abstraction.Generic;

namespace Pustok.BLL.Services.Implementation;

public class ProductManager : CrudManager<Product, ProductViewModel, ProductListViewModel, ProductCreateViewModel, ProductUpdateViewModel>, IProductService
{
    private readonly ITagService _tagService;
    private readonly ICategoryService _categoryService;
    private readonly ICloudinaryService _cloudinaryService;
    private readonly IProductRepository _productRepository;
    private readonly IProductTagService _productTagService;
    private readonly IProductImageRepository _productImageRepository;

    public ProductManager(IRepository<Product> repository, IMapper mapper, ICategoryService categoryService, ITagService tagService, ICloudinaryService cloudinaryService, IProductRepository productRepository, IProductTagService productTagService, IProductImageRepository productImageRepository) : base(repository, mapper)
    {
        _categoryService = categoryService;
        _tagService = tagService;
        _cloudinaryService = cloudinaryService;
        _productRepository = productRepository;
        _productTagService = productTagService;
        _productImageRepository = productImageRepository;
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
        updateViewModel.MainImagePath = product.Images.FirstOrDefault(x => x.IsMain)?.ImageUrl;
        updateViewModel.HoverImagePath = product.Images.FirstOrDefault(x => x.IsHover)?.ImageUrl;
        updateViewModel.AdditionalImagePaths = product.Images.Where(x => x.IsMain == false && x.IsHover ==false).Select(x => x.ImageUrl).ToList();
        updateViewModel.AdditionalImageIds = product.Images.Where(x => x.IsMain == false && x.IsHover ==false).Select(x => x.Id).ToList();
        updateViewModel.AllProductTags = tagsSelectListItem;
        updateViewModel.Categories = categories;
        updateViewModel.SelectedTagsIds = product!.ProductTags.Select(pt => pt.TagId).ToList();

        return updateViewModel;
    }

    public override async Task<ProductViewModel> UpdateAsync(ProductUpdateViewModel updateViewModel)
    {
        var product = await _productRepository.GetAsync( x => x.Id == updateViewModel.Id,include : x => x.Include(x => x.Images));

        if (product == null) throw new NotFoundException("Product not found");

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
                ProductId = product.Id
            };
            await _productTagService.CreateAsync(newTag);
        }
        //main image update
        if (updateViewModel.MainImageFile != null)
        {
            var mainImage = product.Images.FirstOrDefault(x => x.IsMain);
            string newMainImageUrl = await _cloudinaryService.ImageCreateAsync(updateViewModel.MainImageFile!);

            if (mainImage != null)
            {
                await _cloudinaryService.FileDeleteAsync(mainImage.ImageUrl);
                mainImage.ImageUrl = newMainImageUrl;

                await _productImageRepository.UpdateAsync(mainImage);
            }
            else
            {
                ProductImage newMainImage = new()
                {
                    IsHover = true,
                    ImageUrl = newMainImageUrl,
                    Product = product
                };

                product.Images.Add(newMainImage);
            }
        }
        //hover image update
        if (updateViewModel.HovermageFile != null)
        {
            var hoverImage = product.Images.FirstOrDefault(x => x.IsHover);
            string newHoverImageUrl = await _cloudinaryService.ImageCreateAsync(updateViewModel.HovermageFile!);

            if (hoverImage != null)
            {
                await _cloudinaryService.FileDeleteAsync(hoverImage.ImageUrl);
                hoverImage.ImageUrl = newHoverImageUrl;

                await _productImageRepository.UpdateAsync(hoverImage);
            }
            else
            {
                ProductImage newHoverImage = new()
                {
                    IsHover = true,
                    ImageUrl = newHoverImageUrl,
                    Product = product
                };

                product.Images.Add(newHoverImage);
            }
        }

        #region Delete Old Images

        // burda producttun additionnal imagelerin IDlerin gotururuk
        var oldImgIds = product.Images
            .Where(x => x.IsMain == false && x.IsHover == false)
            .Select(x => x.Id)
            .ToList();

        // burda baxiriq eger updateVmda olmayan kohne sekillerli pozuruq
        foreach (var imageId in oldImgIds)
        {
            var isExist = updateViewModel.AdditionalImageIds.Any(x => x == imageId);

            if (isExist is false)
            {
                
                var image = await _productImageRepository.GetAsync(x => x.Id == imageId);

                if (image != null)
                {
                    await _cloudinaryService.FileDeleteAsync(image.ImageUrl);

                    await _productImageRepository.RemoveAsync(image);
                }
            }
        }

        #endregion

        #region Create New Images

        // teze elave olunan sekilleri yardiriq
        foreach (var image in updateViewModel.AdditionalImages)
        {
            string imagePath = await _cloudinaryService.ImageCreateAsync(image);

            ProductImage productImage = new()
            {
                ImageUrl = imagePath,
                Product = product
            };

            product.Images.Add(productImage);
        }

        #endregion


        product = _mapper.Map(updateViewModel, product);

        await _productRepository.UpdateAsync(product);
        
        return new ProductViewModel { };
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

    public async Task<List<ProductViewModel>> GetProductsByCategoryIdAsync(int id)
    {
        var products=await _productRepository.GetAllAsync(x=>x.CategoryId==id);

        var vm = _mapper.Map<List<ProductViewModel>>(products);

        return vm;
    }


    public async Task<ProductDetailsViewModel> GetProductDetailsAsync(int productId)
    {
        var product = await _productRepository.GetAsync(
               predicate: x => x.Id == productId,include: query => query.Include(p => p.Category).Include(p => p.Images).Include(p => p.ProductTags));

        if (product == null)
            throw new NotFoundException("Product not found");

        var productVM = new ProductDetailsViewModel()
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.OriginalPrice,
            DisCountPrice = product.OriginalPrice * (product.DiscountPercentage / 100m == 0 ? 1 : product.DiscountPercentage / 100m),
            ProductCode = product.ProductCode,
            Brand = product.Brand,
            Availability = product.InStock,
            RewardPoints = product.RewardPoint,
            CategoryName = product.Category.Name,
            MainImageUrl = product.Images.FirstOrDefault(x => x.IsMain)?.ImageUrl ?? "undefined",
            AdditionalImageUrls = product.Images.Where(x => x.IsMain == false && x.IsHover == false).Select(x => x.ImageUrl).ToList()
        };

        return productVM;
    }
}
