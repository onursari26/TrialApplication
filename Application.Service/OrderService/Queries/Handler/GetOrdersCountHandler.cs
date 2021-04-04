using MediatR;
using Application.Core.Interfaces;
using Application.Data.Entities.Concrete;
using Application.Dto.Response;
using Application.Service.OrderService.Queries.Query;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Service.OrderService.Queries.Handler
{
    public class GetOrdersCountHandler : IRequestHandler<GetOrdersCount, ResponseInfo<int>>
    {
        private readonly IUnitOfWork _uow;

        public GetOrdersCountHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<ResponseInfo<int>> Handle(GetOrdersCount request, CancellationToken cancellationToken)
        {
            return new ResponseInfo<int> { Data = await _uow.Repository<Order>().CountAsync() };
        }
    }
}
