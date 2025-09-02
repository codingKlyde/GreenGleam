using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenGleam.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixedTypo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProducImage",
                table: "OrderItems",
                newName: "ProductImage");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductImage",
                table: "OrderItems",
                newName: "ProducImage");
        }
    }
}
