using Microsoft.AspNetCore.Identity;

namespace Pustok.DAL.DataContext.Entities;

public class AppUser : IdentityUser
{
    public string? Fullname { get; set; }
    public bool IsActive { get; set; } = true;
    public List<BasketItem> BasketItems { get; set; } = [];
}
