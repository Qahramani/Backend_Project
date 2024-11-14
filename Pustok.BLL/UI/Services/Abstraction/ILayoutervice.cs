namespace Pustok.BLL.UI.Services.Abstraction;

public interface ILayoutervice
{
    Task<Dictionary<string,string>> GetLayoutSettingsAsync();
}
