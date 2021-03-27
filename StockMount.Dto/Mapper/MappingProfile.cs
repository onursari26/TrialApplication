using AutoMapper;
using Application.Data.Entities.Concrete;
using Application.Dto.Concrete;

namespace Application.Dto.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, OrderDto>()
                //.ForMember(o => o.OrderStatus, dto => dto.MapFrom(y => Enum.GetName(typeof(OrderStatus), y.OrderStatus)))
                .ReverseMap();

            CreateMap<OrderDetail, OrderDetailDto>().ReverseMap();
            CreateMap<Store, StoreDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
