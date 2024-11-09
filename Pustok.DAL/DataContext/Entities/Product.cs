using Pustok.DAL.DataContext.Entities.Common;

namespace Pustok.DAL.DataContext.Entities;

public class Product : Timestample
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string ProductCode { get; set; }
    public required string Brand { get; set; }
    public required string Color { get; set; }
    public decimal OriginalPrice { get; set; }
    public decimal DiscountPrice { get; set; }
    public decimal Tax { get; set; }
    public bool InStock { get; set; }
    public bool InDeleted { get; set; }
    public int StockQuantity { get; set; }
    public int Rating { get; set; }
    public int RewardPoint { get; set; }

    public int CategoryId { get; set; }
    public Category? Category{ get; set; }
    public List<ProductImage> Images { get; set; } = [];
    public List<ProductTag> ProductTags { get; set; } = [];
}
