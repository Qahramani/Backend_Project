using FluentValidation;

namespace Pustok.BLL.Validators.ServiceViewModelValidations;

public class ServiceUpdateViewModelValidation : AbstractValidator<ServiceCreateViewModel>
{
    public ServiceUpdateViewModelValidation()
    {
        RuleFor(x => x.MainText).NotEmpty().WithMessage("Cannot be empty").MaximumLength(50).WithMessage("Length should be less than 50");
        RuleFor(x => x.SubText).NotEmpty().WithMessage("Cannot be empty").MaximumLength(50).WithMessage("Length should be less than 50");
        RuleFor(x => x.IconUrl).NotEmpty().WithMessage("Cannot be empty");
    }
}