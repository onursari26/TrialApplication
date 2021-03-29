using Application.Data.Entities.Concrete;
using Application.Dto.Concrete;
using AutoMapper;

namespace Application.Dto.Mapper
{
    class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserDto>()
            .ForMember(dto => dto.NameSurname, u => u.MapFrom(y => y.Name + " " + y.Surname))
            .ReverseMap();
        }
    }
}
