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
    public decimal DiscountPrice { get; set; }
    public decimal Tax { get; set; }
    public bool InStock { get; set; } = false;
    public bool IsDeleted { get; set; } = false;
    public int StockQuantity { get; set; }
    public int Rating { get; set; }
    public int RewardPoint { get; set; }
    public int CategoryId { get; set; }
    public CategoryViewModel? Category { get; set; }
    public List<ProductImageViewModel> Images { get; set; } = [];
    public List<ProductTagViewModel> ProductTags { get; set; } = [];
}
public class ProductCreateViewModel : IViewModel
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? ProductCode { get; set; }
    public string? Brand { get; set; }
    public string? Color { get; set; }
    public decimal OriginalPrice { get; set; }
    public decimal DiscountPrice { get; set; }
    public decimal Tax { get; set; }
    public bool InStock { get; set; } = false;
    public int StockQuantity { get; set; }
    public int RewardPoint { get; set; }
    public int CategoryId { get; set; } 
    public List<CategoryViewModel>? Categories { get; set; }
    public IFormFile MainImage { get; set; }
    public List<IFormFile> SecondaryImages { get; set; } = [];
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
    public decimal DiscountPrice { get; set; }
    public decimal Tax { get; set; }
    public bool InStock { get; set; } = false;
    public int StockQuantity { get; set; }
    public int RewardPoint { get; set; }
    public int CategoryId { get; set; }
    public List<CategoryViewModel>? Categories { get; set; }
    public List<ProductImage> Images { get; set; } = [];
    //public List<IFormFile>? NewImages { get; set; } = [];
    public List<SelectListItem> OldProductTags { get; set; } = [];
    public List<int> SelectedTagsIds { get; set; } = [];
    public List<SelectListItem> AllProductTags { get; set; } = [];
    public List<int> TagsIds { get; set; } = [];
}
public class ProductListViewModel : PageableViewModel, IViewModel
{
    public List<ProductViewModel> Items { get; set; } = [];
}