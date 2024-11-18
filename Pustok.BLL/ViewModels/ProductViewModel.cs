using Microsoft.AspNetCore.Http;

namespace Pustok.BLL.ViewModels;

public class ProductViewModel : IViewModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? ProductCode { get; set; }
    public string? Brand { get; set; }
    public string? Color { get; set; }
    public decimal OriginalPrice { get; set; }
    public int DiscountPercentage { get; set; }
    public decimal Tax { get; set; }
    public bool InStock { get; set; } = false;
    public bool IsDeleted { get; set; } = false;
    public int StockQuantity { get; set; }
    public int SalesCount { get; set; }
    public int Rating { get; set; }
    public int RewardPoint { get; set; }
    public int CategoryId { get; set; }
    public CategoryViewModel? Category { get; set; }
    public List<ProductImageViewModel> Images { get; set; } = [];
    public List<ProductTagViewModel> ProductTags { get; set; } = [];

    public decimal DiscountPrice() => OriginalPrice * ((DiscountPercentage / 100m) == 0 ? 1 : (DiscountPercentage / 100m));

}
public class ProductCreateViewModel : IViewModel
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? ProductCode { get; set; }
    public string? Brand { get; set; }
    public string? Color { get; set; }
    public decimal OriginalPrice { get; set; }
    public decimal DiscountPercentage { get; set; }
    public decimal Tax { get; set; }
    public bool InStock { get; set; } = false;
    public int StockQuantity { get; set; }
    public int RewardPoint { get; set; }
    public int CategoryId { get; set; } 
    public List<CategoryViewModel>? Categories { get; set; }
    public IFormFile MainFile { get; set; } = null!;
    public IFormFile HoverFile { get; set; } = null!;
    public List<IFormFile> AdditionalImages { get; set; } = [];
    public List<int> SelectedTagIds { get; set; } = [];
    public List<SelectListItem> Tags { get; set; } = [];

}
public class ProductUpdateViewModel : IViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ProductCode { get; set; }
    public string Brand { get; set; }
    public string? Color { get; set; }
    public decimal OriginalPrice { get; set; }
    public int DiscountPercentage { get; set; }
    public decimal Tax { get; set; }
    public bool InStock { get; set; } = false;
    public int StockQuantity { get; set; }
    public int RewardPoint { get; set; }
    public int CategoryId { get; set; }
    public List<CategoryViewModel>? Categories { get; set; }

    public string? MainImagePath { get; set; }
    public IFormFile? MainImageFile { get; set; }
    public string? HoverImagePath { get; set; }
    public IFormFile? HovermageFile { get; set; }
    public List<string> AdditionalImagePaths { get; set; } = [];
    public List<IFormFile> AdditionalImages { get; set; } = [];
    public List<int> AdditionalImageIds { get; set; } = [];
    public List<int> SelectedTagsIds { get; set; } = [];
    public List<SelectListItem> AllProductTags { get; set; } = [];
    public List<int> TagsIds { get; set; } = [];
}
public class ProductListViewModel : PageableViewModel, IViewModel
{
    public List<ProductViewModel> Items { get; set; } = [];
}




public class ProductDetailsViewModel : IViewModel
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public decimal Price { get; set; }
    public decimal? DisCountPrice { get; set; }
    public string? ProductCode { get; set; }
    public string? Brand { get; set; }
    public bool Availability { get; set; }
    public int RewardPoints { get; set; }
    public string? MainImageUrl { get; set; }
    public List<string> AdditionalImageUrls { get; set; } = new();
    public required string CategoryName { get; set; }
}



