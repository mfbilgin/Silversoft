using Dtos.Role;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation.RoleValidators;

public class RoleUpdateValidator : AbstractValidator<RoleUpdateDto>
{
    public RoleUpdateValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Role name cannot be empty.");
        RuleFor(x => x.Name).NotNull().WithMessage("Role name cannot be null.");
        RuleFor(x => x.Name).MinimumLength(3).WithMessage("Role name must be at least 3 characters.");
        RuleFor(x => x.Name).MaximumLength(50).WithMessage("Role name must be at most 50 characters.");
    }
}