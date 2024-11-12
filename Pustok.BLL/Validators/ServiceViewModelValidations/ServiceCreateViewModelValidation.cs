using FluentValidation;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Pustok.BLL.Validators.ServiceViewModelValidations;

public class ServiceCreateViewModelValidation : AbstractValidator<ServiceCreateViewModel>
{
    public ServiceCreateViewModelValidation()
    {
        RuleFor(x => x.MainText).NotEmpty().WithMessage("Cannot be empty").MaximumLength(50).WithMessage("Length should be less than 50");
        RuleFor(x => x.SubText).NotEmpty().WithMessage("Cannot be empty").MaximumLength(50).WithMessage("Length should be less than 50");
        RuleFor(x => x.IconUrl).NotEmpty().WithMessage("Cannot be empty");
    }
}
