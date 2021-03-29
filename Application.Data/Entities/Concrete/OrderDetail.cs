using Application.Data.Entities.Abstract;
using System;

namespace Application.Data.Entities.Concrete
{
    public class OrderDetail : Entity
    {
        public long StoreId { get; set; }
        public long OrderId { get; set; }
        public int ProductId { get; set; }
        public string IntegrationProductCode { get; set; }
        public string IntegrationOrderDetailId { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public string ProductCode2 { get; set; }
        public string Barcode { get; set; }
        public string ProductImage { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public float RawQuantity { get; set; }
        public float TaxRate { get; set; }
        public bool Invoiced { get; set; }
        public bool Unread { get; set; }
        public int SmUserSchemaId { get; set; }
        public string SchemaName { get; set; }
        public string DeliveryTitle { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string CargoCompany { get; set; }
        public string CargoLabelCode { get; set; }
        public string CargoPayment { get; set; }
        public DateTime CargoDate { get; set; }
        public string VariantProductCode { get; set; }
        public string VariantName1 { get; set; }
        public string VariantValue1 { get; set; }
        public string VariantName2 { get; set; }
        public string VariantValue2 { get; set; }
        public string VariantName3 { get; set; }
        public string VariantValue3 { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string VariantProductBarcode { get; set; }
        public string VariantPhrase { get; set; }
        public string ShipmentCampaignCode { get; set; }
        public string InvoiceNumber { get; set; }
        public string PackageNumber { get; set; }
        public string WayBillNumber { get; set; }
        public DateTime InvoiceTime { get; set; }
        public DateTime PackageTime { get; set; }
        public DateTime WayBillTime { get; set; }
        public string MerchantSku { get; set; }
        public int DetailType { get; set; }
        public string PaymentMethod { get; set; }
        public string OrderStatus { get; set; }
        public string PostalCode { get; set; }
        public DateTime LastModificationTime { get; set; }
        public string ProductUnit { get; set; }
        public string ProductVariantCode { get; set; }
        public Order Order { get; set; }


    }
}
