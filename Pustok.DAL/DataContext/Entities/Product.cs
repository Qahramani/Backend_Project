using Pustok.DAL.DataContext.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pustok.DAL.DataContext.Entities;

public class Product : BaseEntity
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string ProductCode { get; set; }
    public required string Brand { get; set; }
    public required string Color { get; set; }
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
    public Category? Category{ get; set; }
    public List<ProductImage> Images { get; set; } = [];
    public List<ProductTag> ProductTags { get; set; } = [];
    
}
