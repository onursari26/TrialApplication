using MediatR;
using Newtonsoft.Json;
using Application.Dto.Concrete;
using Application.Dto.Response;
using Application.Service.Abstract;
using System.Collections.Generic;

namespace Application.Service.OrderService.Queries.Query
{
    public class GetOrdersQuery : BaseCQ, IRequest<ResponseInfo<List<OrderDto>>>
    {
        [JsonProperty("storeId")]
        public int StoreId { get; set; }
        [JsonProperty("orderStatus")]
        public string OrderStatus { get; set; }
        [JsonProperty("invoiceStatus")]
        public int InvoiceStatus { get; set; }
    }
}
