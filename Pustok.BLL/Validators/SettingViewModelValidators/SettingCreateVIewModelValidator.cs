using FluentValidation;

namespace Pustok.BLL.Validators.SettingViewModelValidators;

public class SettingCreateVIewModelValidator : AbstractValidator<SettingCreateViewModel>
{
    public SettingCreateVIewModelValidator()
    {
        RuleFor(x => x.Key).NotEmpty().WithMessage("Cannot be empty");
        RuleFor(x => x.Key).NotEmpty().WithMessage("Cannot be empty");
    }
}
