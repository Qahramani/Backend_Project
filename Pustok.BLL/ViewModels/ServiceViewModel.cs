using Pustok.DAL.Paging;
using System.Drawing.Printing;

namespace Pustok.BLL.ViewModels;

public class ServiceViewModel : IViewModel
{
    public int Id { get; set; }
    public string? MainText { get; set; }
    public string? SubText { get; set; }
    public string? IconUrl { get; set; }
}
public class ServiceCreateViewModel : IViewModel
{
    public string? MainText { get; set; }
    public string? SubText { get; set; }
    public string? IconUrl { get; set; }
}

public class ServiceUpdateViewModel : IViewModel
{
    public int Id { get; set; }
    public string? MainText { get; set; }
    public string? SubText { get; set; }
    public string? IconUrl { get; set; }
}

public class ServiceListViewModel : PageableViewModel, IViewModel
{
    public List<ServiceViewModel> Items { get; set; } = [];
}
