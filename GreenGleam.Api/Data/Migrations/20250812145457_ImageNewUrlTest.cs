using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenGleam.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class ImageNewUrlTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "Image",
                value: "image/product/dill.png");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "Image",
                value: "image/dill.png");
        }
    }
}
