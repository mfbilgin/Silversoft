using Business.Constants;
using Core.Exceptions;
using Core.Security.Authorization;
using Core.Security.Hashing;
using DataAccess.Abstracts;
using Entities.Concretes;
using Entities.Enums;
using Microsoft.AspNetCore.Http;

namespace Business.BusinessRules;

public sealed class UserBusinessRules(IUserRepository userRepository, IRoleRepository roleRepository)
{
    public void UsernameCanNotBeDuplicatedWhenUpdated(string username, Guid id)
    {
        var user = userRepository.GetByUsername(username);
        if (user is not null && user.Id != id)
        {
            throw new BusinessException(UserMessages.UsernameAlreadyExists, StatusCodes.Status409Conflict);
        }
    }
    public void UsersJustCanUpdateTheirOwnInformations(Guid requestedUserId)
    {
        if (requestedUserId != JwtHelper.GetAuthenticatedUserId())
        {
            throw new BusinessException(UserMessages.UserCanNotUpdateOtherUser, StatusCodes.Status403Forbidden);
        }
    }
    public void EmailCanNotBeDuplicatedWhenUpdated(string email, Guid id)
    {
        var user = userRepository.GetByEmail(email);
        if (user is not null && user.Id != id)
        {
            throw new BusinessException(UserMessages.EmailAlreadyExists, StatusCodes.Status409Conflict);
        }
    }
    public void StudentNumberCanNotBeDuplicatedWhenUpdated(string? studentNumber, Guid id)
    {
        var user = userRepository.GetByStudentNumber(studentNumber);
        if (user is not null && user.Id != id)
        {
            throw new BusinessException(UserMessages.StudentNumberAlreadyExists, StatusCodes.Status409Conflict);
        }
    }
    
    public void UserIdMustBeExist(Guid id)
    {
        var user = userRepository.GetById(id);
        if (user is null)
        {
            throw new BusinessException(UserMessages.UserNotFound, StatusCodes.Status404NotFound);
        }
    }
    
    public User UsernameMustBeExist(string username)
    {
        var user = userRepository.GetByUsername(username);
        if (user is null)
        {
            throw new BusinessException(UserMessages.UserNotFound, StatusCodes.Status404NotFound);
        }

        return user;
    }

    public void SetUserRoleAsStudentIfRequestHasStudentNumber(User user)
    {
        if (string.IsNullOrEmpty(user.StudentNumber))
        {
            user.RoleId = roleRepository.GetByName(SystemRoles.User.ToString().ToLower())!.Id;
            return;
        }

        user.RoleId = roleRepository.GetByName(SystemRoles.Student.ToString().ToLower())!.Id;
    }

    public void CurrentPasswordMustBeCorrect(User user, string currentPassword)
    {
        if (HashingHelper.VerifyPasswordHash(currentPassword, user.PasswordHash, user.PasswordSalt) is false)
        {
            throw new BusinessException(UserMessages.CurrentPasswordIsIncorrect, StatusCodes.Status400BadRequest);
        }
    }

    public void PasswordsCanNotBeSame(string currentPassword, string newPassword)
    {
        if (currentPassword == newPassword)
        {
            throw new BusinessException(UserMessages.NewPasswordMustBeDifferent, StatusCodes.Status400BadRequest);
        }
    }

    public Role RoleMustBeExistWhenUserRoleUpdated(string roleName)
    {
        var role = roleRepository.GetByName(roleName);
        if (role is null)
        {
            throw new BusinessException(RoleMessages.RoleNotFound, StatusCodes.Status404NotFound);
        }

        return role;
    }
}