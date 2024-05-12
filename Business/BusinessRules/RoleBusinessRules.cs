using Business.Constants;
using DataAccess.Abstracts;

namespace Business.BusinessRules;

public class RoleBusinessRules(IRoleRepository roleRepository)
{
    public void RoleNameCanNotBeDuplicated(string name)
    {
        var role = roleRepository.GetByName(name);
        if (role is not null)
        {
            throw new Exception(RoleMessages.RoleNameAlreadyExists);
        }
    }
    public void RoleIdCanBeExist(Guid id)
    {
        var role = roleRepository.GetById(id);
        if (role is null)
        {
            throw new Exception(RoleMessages.RoleNotFound);
        }
    }
}