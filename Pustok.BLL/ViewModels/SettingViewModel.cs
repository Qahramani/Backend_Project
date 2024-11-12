namespace Pustok.BLL.ViewModels;

public class SettingViewModel : IViewModel
{
    public int Id { get; set; }
    public string? Key { get; set; }
    public string? Value { get; set; }
}

public class SettingCreateViewModel : IViewModel
{
    public string? Key { get; set; }
    public string? Value { get; set; }
}
public class SettingUpdateViewModel : IViewModel
{
    public int Id { get; set; }
    public string? Key { get; set; }
    public string? Value { get; set; }
}
public class SettingListViewModel : PageableViewModel ,IViewModel
{
    public List<SettingViewModel> Items { get; set; } = [];
}