using Pustok.DAL.DataContext.Entities.Common;

namespace Pustok.DAL.DataContext.Entities;

public class Tag : BaseEntity
{
    public required string Link { get; set; }
    public List<ProductTag> ProductTags { get; set; } = [];
}
