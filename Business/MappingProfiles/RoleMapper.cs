using AutoMapper;
using Core.Extensions.Paging;
using Dtos.Role;
using Entities.Concretes;

namespace Business.MappingProfiles;

public class RoleMapper : Profile
{
    public RoleMapper()
    {
        CreateMap<Role, RoleAddDto>().ReverseMap();
        CreateMap<Role, RoleUpdateDto>().ReverseMap();
        CreateMap<Role, RoleDeleteDto>().ReverseMap();
        CreateMap<Role, RoleGetDto>().ReverseMap();
        CreateMap<PageableModel<Role>, PageableModel<RoleGetDto>>().ReverseMap();
    }
}