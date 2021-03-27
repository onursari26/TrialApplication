using Microsoft.EntityFrameworkCore;
using Application.Core.Context;
using Application.Data.Entities.Concrete;
using Application.Utility.Hashing;
using System;
using System.Linq;

namespace Application.Core.Seeding
{
    public class Seeds
    {
        public void Seed(AplicationContext context)
        {
            if (context.User.Any())
                return;

            string password = "11223344!";
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            context.User.Add(new User
            {
                Name = "yazilim",
                Surname = "Aplication",
                Email = "yazilim@Application.com",
                Username = "yazilim@Application.com",
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Avatar = "/assets/images/avatar/avatarset01/avatarset01_01.png",
            });

            var store = new Store
            {
                StoreId = 37814,
                Name = "Stock Mount",
                Description = "Stock Mount",
            };

            context.Store.Add(store);

            var store2 = new Store
            {
                StoreId = 37815,
                Name = "Stock Mount",
                Description = "Stock Mount",
            };

            context.Store.Add(store2);

            var store3 = new Store
            {
                StoreId = 37816,
                Name = "Stock Mount",
                Description = "Stock Mount",
            };

            context.Store.Add(store3);

            if (context.Database.ProviderName != "Microsoft.EntityFrameworkCore.InMemory")
            {
                context.Database.OpenConnection();
                try
                {
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Store ON;");
                    context.SaveChanges();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Store OFF;");
                }
                finally
                {
                    context.Database.CloseConnection();
                }
            }

            for (int i = 1; i < 101; i++)
            {
                var order = new Order
                {
                    Name = "Aplication",
                    PersonalIdentification = "11111111111",
                    Nickname = "Aplication",
                    OrderDate = DateTime.Parse("2020-07-06T11:30:48.403Z"),
                    IntegrationOrderCode = "202847319367",
                    OrderStatus = "Completed",
                    Fullname = "Aplication",
                    Address = "Üniversiteler Mh. Odtü Teknokent Silikon Blok Aplication  Çankaya Ankara",
                    Telephone = "5320000000",
                    TaxNumber = "11111111111",
                    City = "Ankara",
                    District = "Çankaya",
                    CompanyTitle = null,
                    Store = store,
                    Email = "Aplication",
                };

                order.OrderDetails.Add(new OrderDetail
                {
                    StoreId = store.StoreId,
                    IntegrationProductCode = "112576403",
                    IntegrationOrderDetailId = "37726242",
                    ProductName = "FIRAT Thermo Kauçuk Bezli Sulama Hortumu 1\" - 50 Metre",
                    ProductCode = "7401000254",
                    Price = 219,
                    Quantity = 1,
                    RawQuantity = 1,
                    Invoiced = true,
                    Unread = false,
                    DeliveryTitle = "Aplication",
                    Address = "Üniversiteler Mh. Odtü Teknokent Silikon Blok Aplication  Çankaya Ankara",
                    Telephone = "5320000000",
                    CargoCompany = "Yurtiçi",
                    CargoLabelCode = "600974982644",
                    CargoPayment = "Mağaza Öder",
                    CargoDate = DateTime.Parse("2016-08-12T21:00:00Z"),
                    District = "Çankaya",
                    City = "Ankara",
                    ShipmentCampaignCode = "601508011309577",
                    MerchantSku = "7401000254",
                    DetailType = 1,
                    OrderStatus = "Completed",
                    LastModificationTime = DateTime.Parse("2020-02-27T14:57:40.793"),
                    ProductUnit = "0",
                });

                order.OrderDetails.Add(new OrderDetail
                {
                    StoreId = store.StoreId,
                    IntegrationProductCode = "119072276",
                    IntegrationOrderDetailId = "37726244",
                    ProductName = "WERT 2251 Saatçi Tornavida Seti 6 Parça",
                    ProductCode = "WERT.2251",
                    Price = 9,
                    Quantity = 1,
                    RawQuantity = 1,
                    TaxRate = 0,
                    Invoiced = true,
                    Unread = false,
                    DeliveryTitle = "Aplication",
                    Address = "Üniversiteler Mh. Odtü Teknokent Silikon Blok Aplication  Çankaya Ankara",
                    Telephone = "5320000000",
                    CargoCompany = "Yurtiçi",
                    CargoLabelCode = "600974982644",
                    CargoPayment = "Mağaza Öder",
                    CargoDate = DateTime.Parse("2016-08-12T21:00:00Z"),
                    District = "Çankaya",
                    City = "Ankara",
                    ShipmentCampaignCode = "601508011309577",
                    MerchantSku = "WERT.2251",
                    DetailType = 1,
                    OrderStatus = "Completed",
                    LastModificationTime = DateTime.Parse("2020-02-27T14:57:40.793"),
                    ProductUnit = "0",
                });

                order.OrderDetails.Add(new OrderDetail
                {
                    StoreId = store.StoreId,
                    IntegrationProductCode = "94191960",
                    IntegrationOrderDetailId = "37726243",
                    ProductName = "CETA FORM 4000M/7ST1 7 Parça Tornavida Takımı - Tornavida Seti",
                    ProductCode = "CETA.4000M/7ST1",
                    Price = 27,
                    Quantity = 1,
                    RawQuantity = 1,
                    Invoiced = true,
                    Unread = false,
                    DeliveryTitle = "Aplication",
                    Address = "Üniversiteler Mh. Odtü Teknokent Silikon Blok Aplication  Çankaya Ankara",
                    Telephone = "5320000000",
                    CargoCompany = "Yurtiçi",
                    CargoLabelCode = "600974982644",
                    CargoPayment = "Mağaza Öder",
                    CargoDate = DateTime.Parse("2016-08-12T21:00:00Z"),
                    District = "Çankaya",
                    City = "Ankara",
                    ShipmentCampaignCode = "601508011309577",
                    MerchantSku = "CETA.4000M/7ST1",
                    DetailType = 1,
                    OrderStatus = "Completed",
                    LastModificationTime = DateTime.Parse("2020-02-27T14:57:40.793"),
                    ProductUnit = "0",
                });

                context.Orders.AddRange(order);

            }

            context.SaveChanges();
        }
    }
}
