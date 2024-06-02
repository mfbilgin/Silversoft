using Core.Extensions.Paging;
using Dtos.User;

namespace Business.Abstracts;

public interface IUserService
{
    public void Add(UserAddDto userAddDto);
    public void Update(UserUpdateDto userUpdateDto);
    public void Delete(UserDeleteDto userDeleteDto);
    public void ChangePassword(ChangePasswordDto changePasswordDto);
    public void ChangeUserRole(ChangeUserRoleDto changeUserRoleDto);
    public PageableModel<UserGetDto> GetAll(int index = 1, int size = 10);
    public UserGetDto? GetById(Guid id);
    UserGetDto? GetByUsername(string name);
}