﻿namespace Pustok.BLL.ViewModels;

public class BasketItemViewModel : IViewModel
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int Count { get; set; }
    public Product? Product { get; set; }
    public string? UserId { get; set; }
    public AppUser? User { get; set; }
}
public class BasketItemCreateViewModel : IViewModel
{
    public int ProductId { get; set; }
    public required string UserId { get; set; }
    public int Count { get; set; }

}

public class BasketItemUpdateViewModel : IViewModel
{
    public int ProductId { get; set; }
    public required string UserId { get; set; }
}
public class BasketItemListViewModel : PageableViewModel, IViewModel
{
    public List<BasketItemViewModel> Items { get; set; } = [];
}

public class BasketItemVM
{
    public int ProductId { get; set; }
    public int Count { get; set; }
}

public class GetBasketViewModel
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string Name { get; set; } = null!;
    public string ImagePath { get; set; } = null!;
    public decimal Price { get; set; }
    public int Count { get; set; }
}