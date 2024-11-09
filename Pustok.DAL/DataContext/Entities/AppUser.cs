﻿using Microsoft.AspNetCore.Identity;

namespace Pustok.DAL.DataContext.Entities;

public class AppUser : IdentityUser
{
    public required string Fullname { get; set; }
    public List<BasketItem> BasketItems { get; set; } = [];
}