using Pustok.BLL.ViewModels;

namespace Pustok.MVC.ViewModels;

public class HeaderViewModel
{
    public Dictionary<string, string>? Settings { get; set; }
    public List<CategoryViewModel> Categories { get; set; } = [];   
}
