using Pustok.DAL.DataContext.Entities.Common;

namespace Pustok.DAL.DataContext.Entities;

public class BasketItem : BaseEntity
{
    public int Count { get; set; }
    public int ProductId { get; set; }
    public Product? Product { get; set; }
    public required string UserId { get; set; }
    public AppUser? User { get; set; }
}
