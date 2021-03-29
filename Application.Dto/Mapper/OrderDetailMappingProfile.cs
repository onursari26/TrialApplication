using Application.Data.Entities.Concrete;
using Application.Dto.Concrete;
using AutoMapper;

namespace Application.Dto.Mapper
{
    class OrderDetailMappingProfile:Profile
    {
        public OrderDetailMappingProfile()
        {
            CreateMap<OrderDetail, OrderDetailDto>().ReverseMap();
        }
    }
}
