﻿namespace Pustok.BLL.ViewModels;

public class ProductTagViewModel : IViewModel
{
    public int TagId { get; set; }
    public TagViewModel? Tag { get; set; }
    public int ProductId { get; set; }
    public ProductViewModel? Product { get; set; }
}