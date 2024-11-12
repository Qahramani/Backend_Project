using Microsoft.AspNetCore.Http;

namespace Pustok.BLL.ViewModels;

public class ProductImageViewModel : IViewModel
{
    public int Id { get; set; }
    public string? ImageUrl { get; set; }
    public bool IsMain { get; set; } = false;
    public bool IsSecondary { get; set; } = false;
}

public class ProductImagePostViewModel : IViewModel
{
    public required IFormFile ImageFile{ get; set; }
    public string? ImageUrl { get; set; }
    public bool IsMain { get; set; } = false;
    public bool IsSecondary { get; set; } = false;
}

public class ProductImageUpdateViewModel : IViewModel
{
    public int Id { get; set; }
    public string? ImageUrl { get; set; }
    public IFormFile? ImageFile { get; set; }
    public bool IsMain { get; set; } = false;
    public bool IsSecondary { get; set; } = false;
}
