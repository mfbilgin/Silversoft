﻿using AutoMapper;
using Business.Abstracts;
using Business.BusinessRules;
using Business.ValidationRules.FluentValidation.UserValidators;
using Core.Aspects.Autofac.Security;
using Core.Aspects.Autofac.Validation;
using Core.Extensions.Paging;
using Core.Security.Hashing;
using DataAccess.Abstracts;
using Dtos.User;
using Entities.Concretes;

namespace Business.Concretes;

public sealed class UserManager(IUserRepository userRepository, UserBusinessRules userBusinessRules, IMapper mapper)
    : IUserService
{
    public void Add(User user)
    {
        user.Id = Guid.NewGuid();
        user.Username = user.Username.ToLower();
        userBusinessRules.SetUserRoleAsStudentIfRequestHasStudentNumber(user);
        userRepository.Add(user);
    }
    [SecurityAspect("all")]
    [ValidationAspect(typeof(UserUpdateValidator))]
    public void Update(UserUpdateDto userUpdateDto)
    {
        userBusinessRules.UsersJustCanUpdateTheirOwnInformations(userUpdateDto.Id);
        userBusinessRules.UserIdMustBeExist(userUpdateDto.Id);
        userBusinessRules.UsernameCanNotBeDuplicatedWhenUpdated(userUpdateDto.Username, userUpdateDto.Id);
        userBusinessRules.EmailCanNotBeDuplicatedWhenUpdated(userUpdateDto.Email, userUpdateDto.Id);
        userBusinessRules.StudentNumberCanNotBeDuplicatedWhenUpdated(userUpdateDto.StudentNumber, userUpdateDto.Id);

        var user = mapper.Map<User>(userUpdateDto);
        userBusinessRules.SetUserRoleAsStudentIfRequestHasStudentNumber(user);
        userRepository.Update(user);
    }

    [SecurityAspect("all")]
    public void Delete(UserDeleteDto userDeleteDto)
    {
        userBusinessRules.UserIdMustBeExist(userDeleteDto.Id);
        var user = mapper.Map<User>(userDeleteDto);
        userRepository.Delete(user);
    }
    
    
    [SecurityAspect("all")]
    public void ChangePassword(ChangePasswordDto changePasswordDto)
    {
        userBusinessRules.UsersJustCanUpdateTheirOwnInformations(changePasswordDto.Id);
        userBusinessRules.PasswordsCanNotBeSame(changePasswordDto.CurrentPassword, changePasswordDto.NewPassword);
        userBusinessRules.UserIdMustBeExist(changePasswordDto.Id);
        var user = mapper.Map<User>(changePasswordDto);
        userBusinessRules.CurrentPasswordMustBeCorrect(user, changePasswordDto.CurrentPassword);
        HashingHelper.CreatePasswordHash(changePasswordDto.NewPassword, out var passwordHash, out var passwordSalt);
        user.PasswordHash = passwordHash;
        user.PasswordSalt = passwordSalt;
        userRepository.Update(user);
    }

    [SecurityAspect("admin")]
    public void ChangeUserRole(ChangeUserRoleDto changeUserRoleDto)
    {
        var user = userBusinessRules.UsernameMustBeExist(changeUserRoleDto.Username);
        var role = userBusinessRules.RoleMustBeExistWhenUserRoleUpdated(changeUserRoleDto.Role);
        user.RoleId = role.Id;
        userRepository.Update(user);
    }

    public void VerifyEmail(string username)
    {
        userRepository.VerifyEmail(username);
    }

    [SecurityAspect("admin")]
    public PageableModel<UserGetDto> GetAll(int index = 1, int size = 10)
    {
        var users = userRepository.GetList(index, size);
        return mapper.Map<PageableModel<UserGetDto>>(users);
    }

    [SecurityAspect("admin")]
    public UserGetDto? GetById(Guid id)
    {
        return mapper.Map<UserGetDto?>(userRepository.GetById(id));
    }
    
    [SecurityAspect("admin")]
    public UserGetDto? GetByUsername(string name)
    {
        return mapper.Map<UserGetDto?>(userRepository.GetByUsername(name));
    }
}