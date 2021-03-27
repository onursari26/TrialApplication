using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Core.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Store",
                columns: table => new
                {
                    StoreId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.StoreId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Surname = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Username = table.Column<string>(nullable: false),
                    Avatar = table.Column<string>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: false),
                    PasswordHash = table.Column<byte[]>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    PersonalIdentification = table.Column<string>(nullable: true),
                    Nickname = table.Column<string>(nullable: true),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    IntegrationOrderCode = table.Column<string>(nullable: true),
                    OrderStatus = table.Column<string>(nullable: true),
                    InvoiceStatus = table.Column<int>(nullable: false),
                    Fullname = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Telephone = table.Column<string>(nullable: true),
                    TaxAuthority = table.Column<string>(nullable: true),
                    TaxNumber = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    District = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    CompanyTitle = table.Column<string>(nullable: true),
                    Member = table.Column<string>(nullable: true),
                    PaymentType = table.Column<string>(nullable: true),
                    StoreId = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Store_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Store",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ApiSession",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApiCode = table.Column<string>(nullable: true),
                    PackageEndDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiSession", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApiSession_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderLines",
                columns: table => new
                {
                    OrderDetailId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreId = table.Column<int>(nullable: false),
                    OrderId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    IntegrationProductCode = table.Column<string>(nullable: true),
                    IntegrationOrderDetailId = table.Column<string>(nullable: true),
                    ProductName = table.Column<string>(nullable: true),
                    ProductCode = table.Column<string>(nullable: true),
                    ProductCode2 = table.Column<string>(nullable: true),
                    Barcode = table.Column<string>(nullable: true),
                    ProductImage = table.Column<string>(nullable: true),
                    Price = table.Column<float>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    RawQuantity = table.Column<float>(nullable: false),
                    TaxRate = table.Column<float>(nullable: false),
                    Invoiced = table.Column<bool>(nullable: false),
                    Unread = table.Column<bool>(nullable: false),
                    SmUserSchemaId = table.Column<int>(nullable: false),
                    SchemaName = table.Column<string>(nullable: true),
                    DeliveryTitle = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Telephone = table.Column<string>(nullable: true),
                    CargoCompany = table.Column<string>(nullable: true),
                    CargoLabelCode = table.Column<string>(nullable: true),
                    CargoPayment = table.Column<string>(nullable: true),
                    CargoDate = table.Column<DateTime>(nullable: false),
                    VariantProductCode = table.Column<string>(nullable: true),
                    VariantName1 = table.Column<string>(nullable: true),
                    VariantValue1 = table.Column<string>(nullable: true),
                    VariantName2 = table.Column<string>(nullable: true),
                    VariantValue2 = table.Column<string>(nullable: true),
                    VariantName3 = table.Column<string>(nullable: true),
                    VariantValue3 = table.Column<string>(nullable: true),
                    District = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    VariantProductBarcode = table.Column<string>(nullable: true),
                    VariantPhrase = table.Column<string>(nullable: true),
                    ShipmentCampaignCode = table.Column<string>(nullable: true),
                    InvoiceNumber = table.Column<string>(nullable: true),
                    PackageNumber = table.Column<string>(nullable: true),
                    WayBillNumber = table.Column<string>(nullable: true),
                    InvoiceTime = table.Column<DateTime>(nullable: false),
                    PackageTime = table.Column<DateTime>(nullable: false),
                    WayBillTime = table.Column<DateTime>(nullable: false),
                    MerchantSku = table.Column<string>(nullable: true),
                    DetailType = table.Column<int>(nullable: false),
                    PaymentMethod = table.Column<string>(nullable: true),
                    OrderStatus = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: false),
                    ProductUnit = table.Column<string>(nullable: true),
                    ProductVariantCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLines", x => x.OrderDetailId);
                    table.ForeignKey(
                        name: "FK_OrderLines_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApiSession_UserId",
                table: "ApiSession",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_OrderId",
                table: "OrderLines",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StoreId",
                table: "Orders",
                column: "StoreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApiSession");

            migrationBuilder.DropTable(
                name: "OrderLines");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Store");
        }
    }
}
