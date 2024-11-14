
using Pustok.DAL.DataContext.Entities.Common;

namespace Pustok.DAL.DataContext.Entities;

public class ProductImage : BaseEntity
{
    public required string ImageUrl { get; set; }
    public bool IsMain { get; set; } = false;
    public bool IsHover { get; set; } = false;
    public int ProductId { get; set; }
    public Product? Product { get; set; }
}