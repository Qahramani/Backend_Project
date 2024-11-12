using FluentValidation;

namespace Pustok.BLL.Validators.SubscribeViewModelValidators;

public class SubscribeCreateViewModelValidator : AbstractValidator<SubscribeCreateViewModel>
{
    public SubscribeCreateViewModelValidator()
    {
        RuleFor(x => x.Email).NotEmpty().WithMessage("Cannot be empty")
            .EmailAddress().WithMessage("Incorrect email address format");
    }
}
