using Microsoft.AspNetCore.Http;

namespace Pustok.BLL.ViewModels;

public class SliderViewModel : IViewModel
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public decimal OriginalPrice { get; set; }
    public decimal DiscountPrice { get; set; }
}

public class SliderCreateViewModel : IViewModel
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string? ImageUrl { get; set; }
    public IFormFile ImageFile { get; set; }
    public decimal OriginalPrice { get; set; }
    public decimal DiscountPrice { get; set; }
}
public class SliderUpdateViewModel : IViewModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    //public string? ImageUrl { get; set; }
    public IFormFile ImageFile { get; set; }
    public decimal OriginalPrice { get; set; }
    public decimal DiscountPrice { get; set; }
}
public class SliderListViewModel : PageableViewModel, IViewModel
{
    public List<SliderViewModel> Items { get; set; } = [];
}