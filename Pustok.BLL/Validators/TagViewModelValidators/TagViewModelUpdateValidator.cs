using FluentValidation;

namespace Pustok.BLL.Validators.TagViewModelValidators;

public class TagViewModelUpdateValidator : AbstractValidator<TagUpdateViewModel>
{
    public TagViewModelUpdateValidator()
    {
        RuleFor(x => x.Link).NotEmpty().MaximumLength(50).WithMessage("Length should be less than 50");
    }
}