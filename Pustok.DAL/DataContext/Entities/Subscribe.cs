using Pustok.DAL.DataContext.Entities.Common;

namespace Pustok.DAL.DataContext.Entities;

public class Subscribe : BaseEntity
{
    public required string Email { get; set; }
    public bool IsActive { get; set; } = true;
}
