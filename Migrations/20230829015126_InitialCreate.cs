using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BangazonBE_SB.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ProductCatagoryId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ProductCatagoryId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    StatusId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "OrderStatuses",
                columns: table => new
                {
                    OrderStatusId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderStatus = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatuses", x => x.OrderStatusId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    ProductCategoryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "UserPaymentTypes",
                columns: table => new
                {
                    UserPaymentTypeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    PaymentId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPaymentTypes", x => x.UserPaymentTypeId);
                });

            migrationBuilder.CreateTable(
                name: "OrdersProducts",
                columns: table => new
                {
                    OrdersOrderId = table.Column<int>(type: "integer", nullable: false),
                    ProductsProductId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersProducts", x => new { x.OrdersOrderId, x.ProductsProductId });
                    table.ForeignKey(
                        name: "FK_OrdersProducts_Orders_OrdersOrderId",
                        column: x => x.OrdersOrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdersProducts_Products_ProductsProductId",
                        column: x => x.ProductsProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentTypes",
                columns: table => new
                {
                    PaymentTypeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Users_PaymentTypesUserPaymentTypeId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTypes", x => x.PaymentTypeId);
                    table.ForeignKey(
                        name: "FK_PaymentTypes_UserPaymentTypes_Users_PaymentTypesUserPayment~",
                        column: x => x.Users_PaymentTypesUserPaymentTypeId,
                        principalTable: "UserPaymentTypes",
                        principalColumn: "UserPaymentTypeId");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    NickName = table.Column<string>(type: "text", nullable: true),
                    TimeCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsSeller = table.Column<bool>(type: "boolean", nullable: false),
                    Users_PaymentTypesUserPaymentTypeId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_UserPaymentTypes_Users_PaymentTypesUserPaymentTypeId",
                        column: x => x.Users_PaymentTypesUserPaymentTypeId,
                        principalTable: "UserPaymentTypes",
                        principalColumn: "UserPaymentTypeId");
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ProductCatagoryId", "Name" },
                values: new object[,]
                {
                    { 1, "Electronics" },
                    { 2, "Clothing" },
                    { 3, "Furniture" }
                });

            migrationBuilder.InsertData(
                table: "OrderStatuses",
                columns: new[] { "OrderStatusId", "OrderStatus" },
                values: new object[,]
                {
                    { 1, "Ordered" },
                    { 2, "Shipped" },
                    { 3, "Completed" },
                    { 4, "Cancelled" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "StatusId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "PaymentTypes",
                columns: new[] { "PaymentTypeId", "Name", "Users_PaymentTypesUserPaymentTypeId" },
                values: new object[,]
                {
                    { 1, "Credit Card", null },
                    { 2, "PayPal", null },
                    { 3, "Cash", null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Name", "Price", "ProductCategoryId", "UserId" },
                values: new object[,]
                {
                    { 1, "Product A", 10.99m, 1, 1 },
                    { 2, "Product B", 20.49m, 2, 2 },
                    { 3, "Product C", 5.99m, 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "UserPaymentTypes",
                columns: new[] { "UserPaymentTypeId", "PaymentId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "IsSeller", "Name", "NickName", "TimeCreated", "Users_PaymentTypesUserPaymentTypeId" },
                values: new object[,]
                {
                    { 1, true, "Jack Smith", "JSmith", new DateTime(2023, 8, 28, 21, 51, 26, 237, DateTimeKind.Local).AddTicks(2775), null },
                    { 2, false, "Chris Lee", "CLee", new DateTime(2023, 8, 28, 21, 51, 26, 237, DateTimeKind.Local).AddTicks(2809), null },
                    { 3, false, "Steve Wilson", "SWilson", new DateTime(2023, 8, 28, 21, 51, 26, 237, DateTimeKind.Local).AddTicks(2811), null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrdersProducts_ProductsProductId",
                table: "OrdersProducts",
                column: "ProductsProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTypes_Users_PaymentTypesUserPaymentTypeId",
                table: "PaymentTypes",
                column: "Users_PaymentTypesUserPaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Users_PaymentTypesUserPaymentTypeId",
                table: "Users",
                column: "Users_PaymentTypesUserPaymentTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "OrdersProducts");

            migrationBuilder.DropTable(
                name: "OrderStatuses");

            migrationBuilder.DropTable(
                name: "PaymentTypes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "UserPaymentTypes");
        }
    }
}
