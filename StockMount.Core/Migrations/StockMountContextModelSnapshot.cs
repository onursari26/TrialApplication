﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Application.Core.Context;

namespace Application.Core.Migrations
{
    [DbContext(typeof(StockMountContext))]
    partial class StockMountContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Application.Data.Entities.Concrete.ApiSession", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApiCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PackageEndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("ApiSession");
                });

            modelBuilder.Entity("Application.Data.Entities.Concrete.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("District")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fullname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IntegrationOrderCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InvoiceStatus")
                        .HasColumnType("int");

                    b.Property<string>("Member")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nickname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrderStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonalIdentification")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StoreId")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TaxAuthority")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TaxNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telephone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrderId");

                    b.HasIndex("StoreId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Application.Data.Entities.Concrete.OrderDetail", b =>
                {
                    b.Property<int>("OrderDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Barcode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CargoCompany")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CargoDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CargoLabelCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CargoPayment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeliveryTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DetailType")
                        .HasColumnType("int");

                    b.Property<string>("District")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IntegrationOrderDetailId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IntegrationProductCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InvoiceNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InvoiceTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Invoiced")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("MerchantSku")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<string>("OrderStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PackageNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PackageTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("PaymentMethod")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<string>("ProductCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductCode2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("ProductImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductUnit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductVariantCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<float>("RawQuantity")
                        .HasColumnType("real");

                    b.Property<string>("SchemaName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShipmentCampaignCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SmUserSchemaId")
                        .HasColumnType("int");

                    b.Property<int>("StoreId")
                        .HasColumnType("int");

                    b.Property<float>("TaxRate")
                        .HasColumnType("real");

                    b.Property<string>("Telephone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Unread")
                        .HasColumnType("bit");

                    b.Property<string>("VariantName1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VariantName2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VariantName3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VariantPhrase")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VariantProductBarcode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VariantProductCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VariantValue1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VariantValue2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VariantValue3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WayBillNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("WayBillTime")
                        .HasColumnType("datetime2");

                    b.HasKey("OrderDetailId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderLines");
                });

            modelBuilder.Entity("Application.Data.Entities.Concrete.Store", b =>
                {
                    b.Property<int>("StoreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StoreId");

                    b.ToTable("Store");
                });

            modelBuilder.Entity("Application.Data.Entities.Concrete.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Application.Data.Entities.Concrete.ApiSession", b =>
                {
                    b.HasOne("Application.Data.Entities.Concrete.User", "User")
                        .WithMany("ApiSessions")
                        .HasForeignKey("UserId")
                        .IsRequired();
                });

            modelBuilder.Entity("Application.Data.Entities.Concrete.Order", b =>
                {
                    b.HasOne("Application.Data.Entities.Concrete.Store", "Store")
                        .WithMany("Orders")
                        .HasForeignKey("StoreId")
                        .IsRequired();
                });

            modelBuilder.Entity("Application.Data.Entities.Concrete.OrderDetail", b =>
                {
                    b.HasOne("Application.Data.Entities.Concrete.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
