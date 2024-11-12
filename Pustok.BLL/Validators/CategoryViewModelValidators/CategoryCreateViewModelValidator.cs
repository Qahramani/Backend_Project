using FluentValidation;
using FluentValidation.AspNetCore;

namespace Pustok.BLL.Validators.CategoryViewModelValidators;

public class CategoryCreateViewModelValidator : AbstractValidator<CategoryCreateViewModel>
{
    public CategoryCreateViewModelValidator()
    {
        RuleFor(x => x.Name).NotNull().MaximumLength(256);
        RuleFor(x => x.ImageFile).SetValidator(new FileValidator());
    }
}
