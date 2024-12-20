﻿namespace Pustok.BLL.ViewModels;

public class TagViewModel : IViewModel
{
    public int Id { get; set; }
    public string? Link { get; set; }
    public List<ProductTagViewModel> ProductTags { get; set; } = [];
}
public class TagCreateViewModel : IViewModel
{
    public string? Link { get; set; }
}
public class TagUpdateViewModel : IViewModel
{
    public int Id { get; set; }
    public string? Link { get; set; }
}
public class TagListViewModel : PageableViewModel, IViewModel
{
    public List<TagViewModel> Items { get; set; } = [];
}