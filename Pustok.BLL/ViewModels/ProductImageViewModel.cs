using Microsoft.AspNetCore.Http;

namespace Pustok.BLL.ViewModels;

public class ProductImageViewModel : IViewModel
{
    public int Id { get; set; }
    public string? ImageUrl { get; set; }
    public bool IsMain { get; set; } = false;
    public bool IsSecondary { get; set; } = false;
}

public class ProductImageCreateViewModel : IViewModel
{
    public string? ImageUrl { get; set; }
    public bool IsMain { get; set; } = false;
    public bool IsSecondary { get; set; } = false;
    public Product? Product { get; set; }
}

public class ProductImageUpdateViewModel : IViewModel
{
    public int Id { get; set; }
    public string? ImageUrl { get; set; }
    public bool IsMain { get; set; } = false;
    public bool IsSecondary { get; set; } = false;
}

public class ProductImageListViewModel : PageableViewModel, IViewModel
{
    public List<ProductImageViewModel> Items { get; set; } = [];
}