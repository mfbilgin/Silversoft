using AutoMapper;
using Business.Abstracts;
using Business.BusinessRules;
using Business.ValidationRules.FluentValidation.RoleValidators;
//using Core.Aspects.Autofac.Security;
using Core.Aspects.Autofac.Validation;
using Core.Extensions.Paging;
using DataAccess.Abstracts;
using Dtos.Role;
using Entities.Concretes;

namespace Business.Concretes;

//[SecurityAspect("admin")]
public class RoleManager(IRoleRepository roleRepository, IMapper mapper,RoleBusinessRules roleBusinessRules) : IRoleService
{
    [ValidationAspect(typeof(RoleAddValidator))]
    public void Add(RoleAddDto roleAddDto)
    {
        roleBusinessRules.RoleNameCanNotBeDuplicated(roleAddDto.Name);
        var role = mapper.Map<Role>(roleAddDto);
        role.Id = Guid.NewGuid();
        roleRepository.Add(role);
    }

    [ValidationAspect(typeof(RoleUpdateValidator))]
    public void Update(RoleUpdateDto roleUpdateDto)
    {
        roleBusinessRules.RoleIdMustBeExist(roleUpdateDto.Id);
        roleBusinessRules.RoleNameCanNotBeDuplicated(roleUpdateDto.Name);

        var role = mapper.Map<Role>(roleUpdateDto);
        roleRepository.Update(role);
    }
    
    public void Delete(RoleDeleteDto roleDeleteDto)
    {
        roleBusinessRules.RoleIdMustBeExist(roleDeleteDto.Id);
        var role = mapper.Map<Role>(roleDeleteDto);

        roleRepository.Delete(role);
    }

    public RoleGetDto? GetById(Guid id)
    {
        var role = roleRepository.GetById(id);
        return mapper.Map<RoleGetDto>(role);
    }
    
    public RoleGetDto? GetByName(string name)
    {
        var role = roleRepository.GetByName(name);
        return mapper.Map<RoleGetDto>(role);
    }

    public PageableModel<RoleGetDto> GetAll(int index = 1, int size = 10)
    {
        var roles = roleRepository.GetList(index, size);
        return mapper.Map<PageableModel<RoleGetDto>>(roles);
    }
}