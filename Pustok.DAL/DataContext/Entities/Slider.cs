using Pustok.DAL.DataContext.Entities.Common;

namespace Pustok.DAL.DataContext.Entities;

public class Slider : BaseEntity
{
    public required string Title { get; set; } 
    public required string Description { get; set; } 
    public required string ImageUrl { get; set; }
    public decimal OriginalPrice { get; set; }
    public decimal DiscountPrice { get; set; }
}
