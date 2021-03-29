using Application.Data.Entities.Abstract;
using System;
using System.Collections.Generic;

namespace Application.Data.Entities.Concrete
{
    public class Order : Entity
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PersonalIdentification { get; set; }
        public string Nickname { get; set; }
        public DateTime OrderDate { get; set; }
        public string IntegrationOrderCode { get; set; }
        public string OrderStatus { get; set; }
        public int InvoiceStatus { get; set; }
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
        public long StoreId { get; set; }
        public string Email { get; set; }
        public Store Store { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
