using AutoMapper;
using Core.Extensions.Paging;
using Dtos.User;
using Entities.Concretes;

namespace Business.MappingProfiles;

public sealed class UserMapper : Profile
{
    public UserMapper()
    {
        CreateMap<User, UserUpdateDto>().ReverseMap();
        CreateMap<User, UserDeleteDto>().ReverseMap();
        CreateMap<User, UserGetDto>().ReverseMap();
        CreateMap<PageableModel<User>, PageableModel<UserGetDto>>().ReverseMap();
    }
}