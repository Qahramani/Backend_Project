using FluentValidation;

namespace Pustok.BLL.Validators.CategoryViewModelValidators;

public class CategoryUpdateViewModelValidator : AbstractValidator<CategoryUpdateViewModel>
{
    public CategoryUpdateViewModelValidator()
    {
        RuleFor(x => x.Name).NotNull().MaximumLength(256);
        RuleFor(x => x.ImageFile).SetValidator(new FileValidator());

    }
}
