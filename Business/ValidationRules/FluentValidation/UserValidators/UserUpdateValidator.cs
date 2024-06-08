using Business.Constants;
using Dtos.User;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation.UserValidators;

public class UserUpdateValidator : AbstractValidator<UserUpdateDto>
{
    public UserUpdateValidator()
    {
        RuleFor(user => user.Username).NotEmpty().NotNull().WithMessage(UserMessages.UsernameCannotBeEmpty);
        RuleFor(user => user.Username).MinimumLength(3).WithMessage(UserMessages.UsernameMustBeAtLeast3Characters);
        RuleFor(user => user.Username).MaximumLength(100).WithMessage(UserMessages.UsernameMustBeAtMost50Characters);

        RuleFor(user => user.FirstName).NotEmpty().NotNull().WithMessage(UserMessages.FirstNameCannotBeEmpty);
        RuleFor(user => user.FirstName).MinimumLength(3).WithMessage(UserMessages.FirstNameMustBeAtLeast3Characters);
        RuleFor(user => user.FirstName).MaximumLength(100).WithMessage(UserMessages.FirstNameMustBeAtMost100Characters);

        RuleFor(user => user.LastName).NotEmpty().NotNull().WithMessage(UserMessages.LastNameCannotBeEmpty);
        RuleFor(user => user.LastName).MinimumLength(3).WithMessage(UserMessages.LastNameMustBeAtLeast3Characters);
        RuleFor(user => user.LastName).MaximumLength(100).WithMessage(UserMessages.LastNameMustBeAtMost100Characters);

        RuleFor(user => user.Email).NotEmpty().NotNull().WithMessage(UserMessages.EmailCannotBeEmpty);
        RuleFor(user => user.Email).EmailAddress().WithMessage(UserMessages.EmailMustBeValid);

        RuleFor(user => user.StudentNumber).Must(IsStudentNumberValid)
            .WithMessage(UserMessages.StudentNumberMustBe10Characters);
        return;

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