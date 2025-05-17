using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechXpress.DAL.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 1,
                column: "AddTime",
                value: new DateTime(2025, 5, 17, 13, 16, 36, 432, DateTimeKind.Local).AddTicks(796));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 2,
                column: "AddTime",
                value: new DateTime(2025, 5, 17, 13, 16, 36, 432, DateTimeKind.Local).AddTicks(880));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 3,
                column: "AddTime",
                value: new DateTime(2025, 5, 17, 13, 16, 36, 432, DateTimeKind.Local).AddTicks(884));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 1,
                column: "AddTime",
                value: new DateTime(2025, 5, 17, 12, 46, 43, 121, DateTimeKind.Local).AddTicks(431));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 2,
                column: "AddTime",
                value: new DateTime(2025, 5, 17, 12, 46, 43, 121, DateTimeKind.Local).AddTicks(557));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 3,
                column: "AddTime",
                value: new DateTime(2025, 5, 17, 12, 46, 43, 121, DateTimeKind.Local).AddTicks(624));
        }
    }
}
