using FluentValidation;

namespace Pustok.BLL.Validators.ProductViewModelValidators;

public class ProductUpdateViewModelValidator : AbstractValidator<ProductUpdateViewModel>
{
    public ProductUpdateViewModelValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Cannot be empty").MaximumLength(255).WithMessage("Lenght should be less than 255");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Cannot be empty").MaximumLength(1024).WithMessage("Lenght should be less than 1024");
        RuleFor(x => x.Brand).NotEmpty().WithMessage("Cannot be empty").MaximumLength(100).WithMessage("Lenght should be less than 100");
        RuleFor(x => x.ProductCode).NotEmpty().WithMessage("Cannot be empty").MaximumLength(100).WithMessage("Lenght should be less than 100");
        RuleFor(x => x.OriginalPrice).GreaterThanOrEqualTo(0).WithMessage("Price cannot be negative");
        RuleFor(x => x.DiscountPrice).GreaterThanOrEqualTo(0).WithMessage("Price cannot be negative");
        RuleFor(x => x.Tax).GreaterThanOrEqualTo(0).WithMessage("Price cannot be negative");
        RuleFor(x => x.RewardPoint).GreaterThanOrEqualTo(0).WithMessage("Cannot be negative");
        RuleFor(x => x.StockQuantity).GreaterThanOrEqualTo(0).WithMessage("Quantity cannot be negative");
        //RuleFor(x => x.MainImage).SetValidator(new FileValidator());
        //RuleFor(x => x.SecondaryImages).NotEmpty();
        //RuleForEach(x => x.SecondaryImages).SetValidator(new FileValidator());
    }
}
