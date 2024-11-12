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

    public CategoryViewModel? Category { get; set; }
    public List<ProductImageViewModel> Images { get; set; } = [];
    public List<ProductTagViewModel> ProductTags { get; set; } = [];
}
public class ProductPostViewModel : IViewModel
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string ProductCode { get; set; }
    public required string Brand { get; set; }
    public string? Color { get; set; }
    public decimal OriginalPrice { get; set; }
    public decimal DiscountPrice { get; set; }
    public decimal Tax { get; set; }
    public bool InStock { get; set; } = false;
    public int StockQuantity { get; set; }
    //public int Rating { get; set; }
    public int RewardPoint { get; set; }

    public List<SelectListItem>? Categories { get; set; }
    public List<int>? CategoryIds { get; set; }
    public List<IFormFile>? Images { get; set; } = [];
    public List<SelectListItem> ProductTags { get; set; } = [];
    public List<int> ProductTagsIds { get; set; } = [];
}
public class ProductUpdateViewModel : IViewModel
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string ProductCode { get; set; }
    public required string Brand { get; set; }
    public string? Color { get; set; }
    public decimal OriginalPrice { get; set; }
    public decimal DiscountPrice { get; set; }
    public decimal Tax { get; set; }
    public bool InStock { get; set; } = false;
    public int StockQuantity { get; set; }
    //public int Rating { get; set; }
    public int RewardPoint { get; set; }

    public List<SelectListItem>? Categories { get; set; }
    public List<int>? CategoryIds { get; set; }
    public List<IFormFile>? Images { get; set; } = [];
    public List<SelectListItem> ProductTags { get; set; } = [];
    public List<int> ProductTagsIds { get; set; } = [];
}
public class ProductListViewModel : PageableViewModel, IViewModel
{
    public List<ProductViewModel> Items { get; set; } = [];
}