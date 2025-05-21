using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechXpress.DAL.Migrations
{
    /// <inheritdoc />
    public partial class deleteCartItemstemwithproduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Products_Product_ID",
                table: "CartItems");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 1,
                column: "AddTime",
                value: new DateTime(2025, 5, 21, 22, 9, 52, 585, DateTimeKind.Local).AddTicks(6973));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 2,
                column: "AddTime",
                value: new DateTime(2025, 5, 21, 22, 9, 52, 585, DateTimeKind.Local).AddTicks(7033));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 3,
                column: "AddTime",
                value: new DateTime(2025, 5, 21, 22, 9, 52, 585, DateTimeKind.Local).AddTicks(7037));

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Products_Product_ID",
                table: "CartItems",
                column: "Product_ID",
                principalTable: "Products",
                principalColumn: "Product_ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Products_Product_ID",
                table: "CartItems");

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
                name: "FK_CartItems_Products_Product_ID",
                table: "CartItems",
                column: "Product_ID",
                principalTable: "Products",
                principalColumn: "Product_ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
