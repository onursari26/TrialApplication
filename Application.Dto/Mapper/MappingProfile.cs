using AutoMapper;

namespace Application.Dto.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            new OrderMappingProfile();

            new OrderDetailMappingProfile();

            new StoreMappingProfile();

            new UserMappingProfile();
        }
    }
}
