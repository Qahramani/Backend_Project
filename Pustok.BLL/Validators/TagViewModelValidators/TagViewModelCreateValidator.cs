using FluentValidation;

namespace Pustok.BLL.Validators.TagViewModelValidators;

public class TagViewModelCreateValidator : AbstractValidator<TagCreateViewModel>
{
    public TagViewModelCreateValidator()
    {
        RuleFor(x => x.Link).NotEmpty().MaximumLength(50).WithMessage("Length should be less than 50");
    }
}
