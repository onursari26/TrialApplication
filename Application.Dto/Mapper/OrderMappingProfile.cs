using Application.Data.Entities.Concrete;
using Application.Dto.Concrete;
using Application.Dto.Enums;
using AutoMapper;
using System;

namespace Application.Dto.Mapper
{
    class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<Order, OrderDto>()
               .ForMember(dto => dto.OrderStatus, o => o.MapFrom(y => (OrderStatus)Enum.Parse(typeof(OrderStatus), y.OrderStatus)))
               .ForMember(dto => dto.NameSurname, o => o.MapFrom(y => y.Name + " " + y.Surname))
               .ForMember(dto => dto.InvoiceStatus, o => o.MapFrom(y => (InvoiceStatus)y.InvoiceStatus))
               .ReverseMap();
        }
    }
}
