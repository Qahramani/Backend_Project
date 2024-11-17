namespace Pustok.BLL.UI.Services.Abstraction;

public interface ILayoutService
{
    Task<Dictionary<string,string>> GetLayoutSettingsAsync();
}
