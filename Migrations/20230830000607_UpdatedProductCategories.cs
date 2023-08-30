using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BangazonBE_SB.Migrations
{
    public partial class UpdatedProductCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentTypes_UserPaymentTypes_Users_PaymentTypesUserPayment~",
                table: "PaymentTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserPaymentTypes_Users_PaymentTypesUserPaymentTypeId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserPaymentTypes",
                table: "UserPaymentTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "UserPaymentTypes",
                newName: "Users_PaymentTypes");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "ProductCategories");

            migrationBuilder.RenameColumn(
                name: "ProductCatagoryId",
                table: "ProductCategories",
                newName: "ProductCategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users_PaymentTypes",
                table: "Users_PaymentTypes",
                column: "UserPaymentTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCategories",
                table: "ProductCategories",
                column: "ProductCategoryId");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "TimeCreated",
                value: new DateTime(2023, 8, 29, 20, 6, 7, 597, DateTimeKind.Local).AddTicks(1306));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "TimeCreated",
                value: new DateTime(2023, 8, 29, 20, 6, 7, 597, DateTimeKind.Local).AddTicks(1350));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "TimeCreated",
                value: new DateTime(2023, 8, 29, 20, 6, 7, 597, DateTimeKind.Local).AddTicks(1352));

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentTypes_Users_PaymentTypes_Users_PaymentTypesUserPayme~",
                table: "PaymentTypes",
                column: "Users_PaymentTypesUserPaymentTypeId",
                principalTable: "Users_PaymentTypes",
                principalColumn: "UserPaymentTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_PaymentTypes_Users_PaymentTypesUserPaymentTypeId",
                table: "Users",
                column: "Users_PaymentTypesUserPaymentTypeId",
                principalTable: "Users_PaymentTypes",
                principalColumn: "UserPaymentTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentTypes_Users_PaymentTypes_Users_PaymentTypesUserPayme~",
                table: "PaymentTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_PaymentTypes_Users_PaymentTypesUserPaymentTypeId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users_PaymentTypes",
                table: "Users_PaymentTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCategories",
                table: "ProductCategories");

            migrationBuilder.RenameTable(
                name: "Users_PaymentTypes",
                newName: "UserPaymentTypes");

            migrationBuilder.RenameTable(
                name: "ProductCategories",
                newName: "Categories");

            migrationBuilder.RenameColumn(
                name: "ProductCategoryId",
                table: "Categories",
                newName: "ProductCatagoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserPaymentTypes",
                table: "UserPaymentTypes",
                column: "UserPaymentTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "ProductCatagoryId");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "TimeCreated",
                value: new DateTime(2023, 8, 28, 21, 51, 26, 237, DateTimeKind.Local).AddTicks(2775));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "TimeCreated",
                value: new DateTime(2023, 8, 28, 21, 51, 26, 237, DateTimeKind.Local).AddTicks(2809));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "TimeCreated",
                value: new DateTime(2023, 8, 28, 21, 51, 26, 237, DateTimeKind.Local).AddTicks(2811));

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentTypes_UserPaymentTypes_Users_PaymentTypesUserPayment~",
                table: "PaymentTypes",
                column: "Users_PaymentTypesUserPaymentTypeId",
                principalTable: "UserPaymentTypes",
                principalColumn: "UserPaymentTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserPaymentTypes_Users_PaymentTypesUserPaymentTypeId",
                table: "Users",
                column: "Users_PaymentTypesUserPaymentTypeId",
                principalTable: "UserPaymentTypes",
                principalColumn: "UserPaymentTypeId");
        }
    }
}
