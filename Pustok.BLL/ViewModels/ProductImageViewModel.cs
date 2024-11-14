using Microsoft.AspNetCore.Http;

namespace Pustok.BLL.ViewModels;

public class ProductImageViewModel : IViewModel
{
    public int Id { get; set; }
    public string? ImageUrl { get; set; }
    public int ProductId { get; set; }
    public bool IsMain { get; set; } 
    public bool IsHover { get; set; } 
}

public class ProductImageCreateViewModel : IViewModel
{
    public string ImageUrl { get; set; } = null!;
    public int ProductId { get; set; }
    public bool IsMain { get; set; } = false;
    public bool IsHover { get; set; } = false;
}

public class ProductImageUpdateViewModel : IViewModel
{
    public int Id { get; set; }
    public string ImageUrl { get; set; } = null!;
    public int ProductId { get; set; }
    public bool IsMain { get; set; }
    public bool IsHover { get; set; } 

}

public class ProductImageListViewModel : PageableViewModel, IViewModel
{
    public List<ProductImageViewModel> Items { get; set; } = [];
}