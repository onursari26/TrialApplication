using Application.Data.Entities.Concrete;
using Application.Dto.Concrete;
using AutoMapper;

namespace Application.Dto.Mapper
{
    class StoreMappingProfile : Profile
    {
        public StoreMappingProfile()
        {
            CreateMap<Store, StoreDto>().ReverseMap();
        }
    }
}
