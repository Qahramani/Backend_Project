using FluentValidation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Pustok.BLL.Services.Abstraction;

namespace Pustok.BLL.Validators.SettingViewModelValidators;

public class SettingCreateVIewModelValidator : AbstractValidator<SettingCreateViewModel>
{
    private readonly ISettingService _settingService;
    public SettingCreateVIewModelValidator(ISettingService settingService)
    {
        _settingService = settingService;

        //RuleFor(x => x.Key).NotNull().NotEmpty().WithMessage("Key Cannot be empty")
        //    .MustAsync(async (key, cancellation) => await _settingService.DoesKeyAlreadyExistAsync(key)
        //).WithMessage("Item with same key already exist");
        RuleFor(x => x.Key).NotNull().NotEmpty().WithMessage("Key Cannot be empty");
        RuleFor(x => x.Value).NotEmpty().WithMessage("Cannot be empty");
    }
}
