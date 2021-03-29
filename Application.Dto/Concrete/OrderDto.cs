using Application.Dto.Abstract;
using Application.Dto.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dto.Concrete
{
    public class OrderDto : EntityDto
    {
        public OrderDto()
        {
            OrderDetails = new HashSet<OrderDetailDto>();
        }
        public int OrderId { get; set; }
        public string NameSurname { get; set; }
        public string PersonalIdentification { get; set; }
        public string Nickname { get; set; }
        public DateTime OrderDate { get; set; }
        public string IntegrationOrderCode { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public InvoiceStatus InvoiceStatus { get; set; }
        public string Fullname { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string TaxAuthority { get; set; }
        public string TaxNumber { get; set; }
        public string City { get; set; }
        public string Notes { get; set; }
        public string District { get; set; }
        public string PostalCode { get; set; }
        public string CompanyTitle { get; set; }
        public string Member { get; set; }
        public string PaymentType { get; set; }
        public int StoreId { get; set; }
        public string Email { get; set; }
        public StoreDto Store { get; set; }
        public ICollection<OrderDetailDto> OrderDetails { get; set; }
    }
}
