using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Pustok.BLL.ViewModels.AccountViewModels;

namespace Pustok.BLL.Validators.AccountVIewModelValidators;

public class RegisterViewModelValidator : AbstractValidator<RegisterViewModel>
{



    //private readonly UserManager<AppUser> userManager;

    //public RegisterViewModelValidator(UserManager<AppUser> _userManager)
    //{
    //    userManager = _userManager;

    //    RuleFor(x => x.Usesrname)
    //        .NotEmpty().WithMessage("Username is required.")
    //        .MustAsync(async (username, cancellation) =>
    //        await userManager.FindByNameAsync(username) == null)
    //        .WithMessage("This username is already taken.");

    //    RuleFor(x => x.Email)
    //        .NotEmpty().WithMessage("Email is required.")
    //        .EmailAddress().WithMessage("Invalid email format.")
    //        .MustAsync(async (email, cancellation) =>
    //        await userManager.FindByEmailAsync(email) == null)
    //        .WithMessage("This email is already registered.");

    //    RuleFor(x => x.Password)
    //        .NotEmpty().WithMessage("Password is required.")
    //        .MinimumLength(4).WithMessage("Password must be at least 4 characters long.")
    //        .CustomAsync(async (password, context, cancellation) =>
    //        {
    //            var user = new AppUser() { Fullname = "gunel"};
    //            var passwordValidator = new PasswordValidator<AppUser>();
    //            var result = await passwordValidator.ValidateAsync(userManager, user, password);

    //            if (!result.Succeeded)
    //            {
    //                foreach (var error in result.Errors)
    //                {
    //                    context.AddFailure(error.Description);
    //                }
    //            }

    //        });

    //    RuleFor(x => x.ConfirmPassword)
    //         .NotEmpty().WithMessage("Password is required.")
    //         .Equal(x => x.Password).WithMessage("Passwords do not match.");

    //}

    public RegisterViewModelValidator()
    {
        RuleFor(x => x.Username)
       .NotEmpty().WithMessage("Username is required.")
      .MaximumLength(100).WithMessage("Max length 100");

        RuleFor(x => x.Email)
       .NotEmpty().WithMessage("Username is required.")
        .EmailAddress().WithMessage("invalid email format");

        RuleFor(x => x.Password)
       .NotEmpty().WithMessage("Password is requred").
       MinimumLength(4).WithMessage("Length should be >= 4");

        RuleFor(x => x.ConfirmPassword)
            .NotEmpty().WithMessage("Confirm Password is required.")
            .Equal(x => x.Password).WithMessage("Passwords do not match.");

    }
}
