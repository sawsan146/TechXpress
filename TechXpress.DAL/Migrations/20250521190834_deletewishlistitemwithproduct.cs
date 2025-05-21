using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechXpress.DAL.Migrations
{
    /// <inheritdoc />
    public partial class deletewishlistitemwithproduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WishListItems_Products_Product_ID",
                table: "WishListItems");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 1,
                column: "AddTime",
                value: new DateTime(2025, 5, 21, 22, 8, 32, 785, DateTimeKind.Local).AddTicks(1648));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 2,
                column: "AddTime",
                value: new DateTime(2025, 5, 21, 22, 8, 32, 785, DateTimeKind.Local).AddTicks(1728));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 3,
                column: "AddTime",
                value: new DateTime(2025, 5, 21, 22, 8, 32, 785, DateTimeKind.Local).AddTicks(1769));

            migrationBuilder.AddForeignKey(
                name: "FK_WishListItems_Products_Product_ID",
                table: "WishListItems",
                column: "Product_ID",
                principalTable: "Products",
                principalColumn: "Product_ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WishListItems_Products_Product_ID",
                table: "WishListItems");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 1,
                column: "AddTime",
                value: new DateTime(2025, 5, 17, 15, 28, 47, 373, DateTimeKind.Local).AddTicks(982));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 2,
                column: "AddTime",
                value: new DateTime(2025, 5, 17, 15, 28, 47, 373, DateTimeKind.Local).AddTicks(1049));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 3,
                column: "AddTime",
                value: new DateTime(2025, 5, 17, 15, 28, 47, 373, DateTimeKind.Local).AddTicks(1053));

            migrationBuilder.AddForeignKey(
                name: "FK_WishListItems_Products_Product_ID",
                table: "WishListItems",
                column: "Product_ID",
                principalTable: "Products",
                principalColumn: "Product_ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
