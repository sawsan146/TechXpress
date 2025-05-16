using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TechXpress.DAL.Migrations
{
    /// <inheritdoc />
    public partial class sedddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Category_ID", "Description", "IsSelected", "Name" },
                values: new object[,]
                {
                    { "1", "All types of personal and gaming laptops.", false, "Laptops" },
                    { "2", "Lightweight, thin laptops with high performance.", false, "Ultrabooks" },
                    { "3", "High-end gaming laptops and accessories.", false, "Gaming" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Product_ID", "AddTime", "Brand", "Category_ID", "Description", "GPU", "Name", "PercentageDiscount", "Price", "PriceAfterDiscount", "Processor", "RAM", "Resolution", "ScreenSize", "Stock", "Storage" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 5, 16, 5, 35, 7, 169, DateTimeKind.Local).AddTicks(2078), "HP", "1", "Powerful laptop with Intel i7, 16GB RAM, and 512GB SSD.", "NVIDIA GTX 1650", "HP Pavilion 15", 10f, 15000m, 13500f, "Intel Core i7", 16, "1920x1080", 15.6m, 20, "512GB SSD" },
                    { 2, new DateTime(2025, 5, 16, 5, 35, 7, 169, DateTimeKind.Local).AddTicks(2158), "Dell", "2", "Affordable performance laptop with 8GB RAM and 256GB SSD.", "Intel Iris Xe", "Dell Inspiron 14", null, 12000m, null, "Intel Core i5", 8, "1920x1080", 14.0m, 15, "256GB SSD" },
                    { 3, new DateTime(2025, 5, 16, 5, 35, 7, 169, DateTimeKind.Local).AddTicks(2162), "Lenovo", "3", "Gaming laptop with Ryzen 7, 16GB RAM, and RTX 3060.", "NVIDIA RTX 3060", "Lenovo Legion 5", 5f, 22000m, 20900f, "AMD Ryzen 7", 16, "2560x1440", 15.6m, 10, "1TB SSD" }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Image_ID", "ImageURL", "Product_ID" },
                values: new object[,]
                {
                    { 1, "HP1.jpeg", 1 },
                    { 2, "HP2.jpeg", 1 },
                    { 3, "Dell1.jpeg", 2 },
                    { 4, "dell2.jpeg", 2 },
                    { 5, "Lenovo1.jpeg", 3 },
                    { 6, "Lenovo2.jpeg", 3 },
                    { 7, "HP3.jpeg", 1 },
                    { 8, "dell3.jpeg", 2 },
                    { 9, "Lenovo3.jpeg", 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Image_ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Image_ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Image_ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Image_ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Image_ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Image_ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Image_ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Image_ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Image_ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Category_ID",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Category_ID",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Category_ID",
                keyValue: "3");
        }
    }
}
