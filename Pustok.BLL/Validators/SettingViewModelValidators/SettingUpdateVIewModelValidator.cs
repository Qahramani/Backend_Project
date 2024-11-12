using FluentValidation;

namespace Pustok.BLL.Validators.SettingViewModelValidators;

public class SettingUpdateVIewModelValidator : AbstractValidator<SettingUpdateViewModel>
{
    public SettingUpdateVIewModelValidator()
    {
        RuleFor(x => x.Key).NotEmpty().WithMessage("Cannot be empty");
        RuleFor(x => x.Key).NotEmpty().WithMessage("Cannot be empty");
    }
}
