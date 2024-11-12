using Microsoft.AspNetCore.Http;
using System.Runtime.InteropServices;

namespace Pustok.BLL.ViewModels;

public class CategoryViewModel : IViewModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? ImageUrl { get; set; }
    public int? ParentCategoryId { get; set; }
    public CategoryViewModel? ParentCategory { get; set; }
    public List<CategoryViewModel> SubCategories { get; set; } = [];
    public List<ProductViewModel> Products { get; set; } = [];
}

public class CategoryPostViewModel : IViewModel
{
    public string? ImageUrl { get; set; }
    public IFormFile ImageFile { get; set; } = null!;
    public string Name { get; set; } = null!;
    public int? ParentCategoryId { get; set; }
    public List<CategoryViewModel> ParentCategories { get; set; } = [];
}

public class CategoryUpdateViewModel : IViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    //public string? ImageUrl { get; set; }
    public IFormFile? ImageFile { get; set; }
    public int? ParentCategoryId { get; set; }
    public List<CategoryViewModel> ParentCategories { get; set; } = [];
}
public class CategoryListViewModel : PageableViewModel, IViewModel
{
    public List<CategoryViewModel> Items { get; set; } = [];
}