using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechXpress.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addimgcol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UploadedImages",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UploadedImages",
                table: "Products");
        }
    }
}
