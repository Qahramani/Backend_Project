using FluentValidation;
using Pustok.BLL.ViewModels.AccountViewModels;

namespace Pustok.BLL.Validators.AccountViewModelValidators;

public class LoginViewModelValidation : AbstractValidator<LoginViewModel>
{
    public LoginViewModelValidation()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
        .EmailAddress().WithMessage("invalid email format");

        RuleFor(x => x.Password)
      .NotEmpty().WithMessage("Password is requred");

    }
}
