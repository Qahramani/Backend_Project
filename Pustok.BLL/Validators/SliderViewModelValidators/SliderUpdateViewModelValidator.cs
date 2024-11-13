using FluentValidation;

namespace Pustok.BLL.Validators.SliderViewModelValidators;

public class SliderUpdateViewModelValidator : AbstractValidator<SliderUpdateViewModel>
{
    public SliderUpdateViewModelValidator()
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage("Cannot be empty").MaximumLength(40).WithMessage("Lenght should be less than 40");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Cannot be empty").MaximumLength(50).WithMessage("Lenght should be less than 50");
        RuleFor(x => x.OriginalPrice).GreaterThanOrEqualTo(0).WithMessage("Price cannot be negative");
        RuleFor(x => x.DiscountPrice).GreaterThanOrEqualTo(0).WithMessage("Price cannot be negative");
        RuleFor(x => x.ImageFile).SetValidator(new FileValidator());
    }
}
