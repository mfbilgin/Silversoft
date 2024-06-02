using AutoMapper;
using Business.Abstracts;
using Business.BusinessRules;
using Business.ValidationRules.FluentValidation.UserValidators;
using Core.Aspects.Autofac.Validation;
using Core.Extensions.Paging;
using Core.Helpers;
using DataAccess.Abstracts;
using Dtos.User;
using Entities.Concretes;

namespace Business.Concretes;

public sealed class UserManager(IUserRepository userRepository,UserBusinessRules userBusinessRules,IMapper mapper) : IUserService
{
    [ValidationAspect(typeof(UserAddValidator))]
    public void Add(User user)
    {
        userBusinessRules.UsernameCanNotBeDuplicatedWhenInserted(user.Username);
        
        user.Username = user.Username.ToLower();
        userBusinessRules.SetUserRoleAsStudentIfRequestHasStudentNumber(user);
        userRepository.Add(user);
    }

    [ValidationAspect(typeof(UserUpdateValidator))]
    public void Update(UserUpdateDto userUpdateDto)
    {
        userBusinessRules.UserIdMustBeExist(userUpdateDto.Id);
        userBusinessRules.UsernameCanNotBeDuplicatedWhenUpdated(userUpdateDto.Username, userUpdateDto.Id);
        var user = mapper.Map<User>(userUpdateDto);
        userBusinessRules.SetUserRoleAsStudentIfRequestHasStudentNumber(user);
        userRepository.Update(user);
    }

    public void Delete(UserDeleteDto userDeleteDto)
    {
        userBusinessRules.UserIdMustBeExist(userDeleteDto.Id);
        var user = mapper.Map<User>(userDeleteDto);
        userRepository.Delete(user);
    }

    public void ChangePassword(ChangePasswordDto changePasswordDto)
    {
        userBusinessRules.PasswordsCanNotBeSame(changePasswordDto.CurrentPassword, changePasswordDto.NewPassword);
        userBusinessRules.UserIdMustBeExist(changePasswordDto.Id);
        var user = mapper.Map<User>(changePasswordDto);
        userBusinessRules.CurrentPasswordMustBeCorrect(user, changePasswordDto.CurrentPassword);
        HashingHelper.CreatePasswordHash(changePasswordDto.NewPassword, out var passwordHash, out var passwordSalt);
        user.PasswordHash = passwordHash;
        user.PasswordSalt = passwordSalt;
        userRepository.Update(user);
    }

    public void ChangeUserRole(ChangeUserRoleDto changeUserRoleDto)
    {
        userBusinessRules.UserIdMustBeExist(changeUserRoleDto.Id);
        var user = userRepository.GetById(changeUserRoleDto.Id)!;
        user.RoleId = changeUserRoleDto.RoleId;
        userRepository.Update(user);
    }

    public PageableModel<UserGetDto> GetAll(int index = 1, int size = 10)
    {
        var users = userRepository.GetList(index, size);
        return mapper.Map<PageableModel<UserGetDto>>(users);
    }
    
    public UserGetDto? GetById(Guid id)
    {
        return mapper.Map<UserGetDto?>(userRepository.GetById(id));
    }
    
    public UserGetDto? GetByUsername(string name)
    {
        return mapper.Map<UserGetDto?>(userRepository.GetByUsername(name));
    }
}