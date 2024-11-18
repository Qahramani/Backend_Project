using FluentValidation;
using Pustok.BLL.ViewModels.AccountViewModels;

namespace Pustok.BLL.Validators.AccountViewModelValidators;

public class ContactEmailSendViewModelValidator : AbstractValidator<ContactEmailSendViewModel>
{
    public ContactEmailSendViewModelValidator()
    {
        RuleFor(x => x.Email)
           .NotEmpty().WithMessage("Email is required.")
       .EmailAddress().WithMessage("invalid email format");

        RuleFor(x => x.FullName)
            .NotEmpty().WithMessage("Fullname cannot be empty")
            .MaximumLength(50).WithMessage("FUlllname is too long");

        RuleFor(x => x.Phone)
            .MaximumLength(12);

        RuleFor(x => x.Message).NotEmpty().WithMessage("cannot be empty")
            .MaximumLength(2000).WithMessage("Too long");
    }
}
