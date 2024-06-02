using Dtos.User;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation.UserValidators;

public class UserUpdateValidator : AbstractValidator<UserUpdateDto>
{
    public UserUpdateValidator()
    {
        RuleFor(user => user.Username).NotEmpty().WithMessage("Username cannot be empty.");
        RuleFor(user => user.Username).NotNull().WithMessage("Username cannot be null.");
        RuleFor(user => user.Username).MinimumLength(3).WithMessage("Username must be at least 3 characters.");
        RuleFor(user => user.Username).MaximumLength(50).WithMessage("Username must be at most 50 characters.");
        
        RuleFor(user => user.FirstName).NotEmpty().WithMessage("Username cannot be empty.");
        RuleFor(user => user.FirstName).NotNull().WithMessage("Username cannot be null.");
        RuleFor(user => user.FirstName).MinimumLength(3).WithMessage("Username must be at least 3 characters.");
        RuleFor(user => user.FirstName).MaximumLength(50).WithMessage("Username must be at most 50 characters.");
        
        RuleFor(user => user.LastName).NotEmpty().WithMessage("Username cannot be empty.");
        RuleFor(user => user.LastName).NotNull().WithMessage("Username cannot be null.");
        RuleFor(user => user.LastName).MinimumLength(3).WithMessage("Username must be at least 3 characters.");
        RuleFor(x => x.LastName).MaximumLength(50).WithMessage("Username must be at most 50 characters.");
        
        RuleFor(user => user.StudentNumber).Must(IsStudentNumberValid).WithMessage("Student number must be 10 characters.");

        bool IsStudentNumberValid(string? studentNumber)
        {
            if (string.IsNullOrWhiteSpace(studentNumber))
            {
                return true;
            }

            return studentNumber.Length == 10;
        }
    }
}