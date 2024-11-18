using Pustok.BLL.ViewModels;
using Pustok.DAL.DataContext.Entities;

namespace Pustok.MVC.ViewModels;

public class FooterViewModel
{
   public Dictionary<string, string>? Settings {  get; set; } 
    public SubscribeCreateViewModel? Subscribe {  get; set; } 
}
