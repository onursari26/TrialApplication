using MediatR;
using Application.Dto.Response;
using Application.Service.Abstract;

namespace Application.Service.OrderService.Queries.Query
{
    public class GetOrdersCount : BaseCQ, IRequest<ResponseInfo<int>>
    {
    }
}
