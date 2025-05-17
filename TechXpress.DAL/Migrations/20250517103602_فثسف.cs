using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechXpress.DAL.Migrations
{
    /// <inheritdoc />
    public partial class فثسف : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 1,
                column: "AddTime",
                value: new DateTime(2025, 5, 17, 13, 36, 2, 410, DateTimeKind.Local).AddTicks(4545));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 2,
                column: "AddTime",
                value: new DateTime(2025, 5, 17, 13, 36, 2, 410, DateTimeKind.Local).AddTicks(4644));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 3,
                column: "AddTime",
                value: new DateTime(2025, 5, 17, 13, 36, 2, 410, DateTimeKind.Local).AddTicks(4650));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
