using Core.Extensions.Paging;
using Dtos.User;
using Entities.Concretes;

namespace Business.Abstracts;

public interface IUserService
{
    public void Add(User user);
    public void Update(UserUpdateDto userUpdateDto);
    public void Delete(UserDeleteDto userDeleteDto);
    public void ChangePassword(ChangePasswordDto changePasswordDto);
    public void ChangeUserRole(ChangeUserRoleDto changeUserRoleDto);
    public PageableModel<UserGetDto> GetAll(int index = 1, int size = 10);
    public UserGetDto? GetById(Guid id);
    UserGetDto? GetByUsername(string name);
}