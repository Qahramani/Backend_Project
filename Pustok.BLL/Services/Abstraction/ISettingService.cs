namespace Pustok.BLL.Services.Abstraction;

public interface ISettingService : ICrudService<Setting, SettingViewModel, SettingListViewModel, SettingCreateViewModel, SettingUpdateViewModel>
{
    Task<bool> DoesKeyAlreadyExistAsync(string key);

}
