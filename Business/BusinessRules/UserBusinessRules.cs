﻿using Business.Constants;
using Core.Exceptions;
using Core.Helpers;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;

namespace Business.BusinessRules;

public sealed class UserBusinessRules(IUserRepository userRepository, IRoleRepository roleRepository)
{
    public void UsernameCanNotBeDuplicatedWhenInserted(string username)
    {
        var user = userRepository.GetByUsername(username);
        if (user is not null)
        {
            throw new BusinessException(UserMessages.UsernameAlreadyExists, StatusCodes.Status409Conflict);
        }
    }
    
    public void UsernameCanNotBeDuplicatedWhenUpdated(string username, Guid id)
    {
        var user = userRepository.GetByUsername(username);
        if (user is not null && user.Id != id)
        {
            throw new BusinessException(UserMessages.UsernameAlreadyExists, StatusCodes.Status409Conflict);
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

    public void SetUserRoleAsStudentIfRequestHasStudentNumber(User user)
    {
        if (string.IsNullOrEmpty(user.StudentNumber))
        {
            user.RoleId = roleRepository.GetByName("user")!.Id;
            return;
        }

        user.RoleId = roleRepository.GetByName("student")!.Id;
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
    
    public void RoleIdMustBeExistWhenUserRoleUpdated(Guid roleId)
    {
        var role = roleRepository.GetById(roleId);
        if (role is null)
        {
            throw new BusinessException(RoleMessages.RoleNotFound, StatusCodes.Status404NotFound);
        }
    }
}