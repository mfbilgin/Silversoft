using Business.Abstracts;
using Business.BusinessRules;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Security;
using Core.Aspects.Autofac.Validation;
using Core.Extensions.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes;

//[SecurityAspect("admin")]
public class RoleManager(IRoleRepository roleRepository) : IRoleService
{
    private readonly RoleBusinessRules _roleBusinessRules = new(roleRepository);

    [ValidationAspect(typeof(RoleValidator))]
    public void Add(Role role)
    {
        _roleBusinessRules.RoleNameCanNotBeDuplicated(role.Name);
        roleRepository.Add(role);
    }
    
    [ValidationAspect(typeof(RoleValidator))]
    public void Update(Role role)
    {
        _roleBusinessRules.RoleNameCanNotBeDuplicated(role.Name);
        roleRepository.Update(role);
    }

    public void Delete(Role role)
    {
        _roleBusinessRules.RoleIdCanBeExist(role.Id);
        roleRepository.Delete(role);
    }
    public Role? GetById(Guid id)
    {
        return roleRepository.GetById(id);
    }
    public PageableModel<Role> GetAll(int index = 1, int size = 10)
    {
        return roleRepository.GetList(index, size);
    }
    public Role? GetByName(string name)
    {
        return roleRepository.GetByName(name);
    }
}