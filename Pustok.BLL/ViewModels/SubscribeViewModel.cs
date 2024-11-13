namespace Pustok.BLL.ViewModels;

public class SubscribeViewModel : IViewModel
{
    public int Id { get; set; }
    public string? Email { get; set; }
    public bool IsActive { get; set; } 
}
public class SubscribeCreateViewModel : IViewModel
{
    public string? Email { get; set; }
    public bool IsActive { get; set; } = true;
}
public class SubscribeUpdateViewModel : IViewModel
{
    public int Id { get; set; }
    public string? Email { get; set; }
    public bool IsActive { get; set; }
}

public class SubscribeListViewModel : PageableViewModel, IViewModel
{
    public List<SubscribeViewModel> Items { get; set; } = [];
}

