using AutoMapper;
using MediatR;
using Application.Core.Interfaces;
using Application.Data.Entities;
using Application.Data.Entities.Concrete;
using Application.Dto.Concrete;
using Application.Dto.Response;
using Application.Service.OrderService.Queries.Query;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace Application.Service.OrderService.Queries.Handler
{
    public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, ResponseInfo<List<OrderDto>>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetOrdersQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<ResponseInfo<List<OrderDto>>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await _uow.Repository<Order>().PagingAsync(
                filter: x => x.StoreId == request.StoreId && x.OrderStatus == request.OrderStatus && x.InvoiceStatus == request.InvoiceStatus,
                orderBy: m => m.OrderBy(x => x.OrderDate),
                includes: null,
                //new System.Linq.Expressions.Expression<Func<Order, object>>[1] { x => x.OrderDetails },
                page: request.Page,
                pageSize: request.PageSize
                );

            return new ResponseInfo<List<OrderDto>>
            {
                Response = _mapper.Map<List<OrderDto>>(orders),
                TotalCount = await _uow.Repository<Order>().CountAsync(x => x.StoreId == request.StoreId && x.OrderStatus == request.OrderStatus && x.InvoiceStatus == request.InvoiceStatus)
            };
        }
    }
}
