using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GreenGleam.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Image", "Name", "Price", "Unit" },
                values: new object[] { "Sweet and tart blueberries packed with antioxidants.", "blueberry.png", "Blueberry", 250.00m, "kg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Image", "Name", "Price", "Unit" },
                values: new object[] { "Crunchy carrots full of vitamins and nutrients.", "carrot.png", "Carrot", 50.00m, "kg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Image", "Name", "Price", "Unit" },
                values: new object[] { "Sweet golden corn on the cob, ready to boil or grill.", "corn.png", "Corn", 20.00m, "piece" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Image", "Name", "Price" },
                values: new object[] { "Fresh dill herb for seasoning and garnishing.", "dill.png", "Dill", 25.00m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "Image", "Name", "Price", "Unit" },
                values: new object[] { "Fresh eggplant perfect for grilling or stir-frying.", "eggplant.png", "Eggplant", 40.00m, "kg" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Image", "Name", "Price", "Unit" },
                values: new object[,]
                {
                    { 6, "Aromatic garlic bulbs, essential for cooking.", "garlic.png", "Garlic", 80.00m, "kg" },
                    { 7, "Sweet seedless grapes, perfect for snacking.", "grapes.png", "Grapes", 20.50m, "kg" },
                    { 8, "Fresh leeks with mild onion-like flavor.", "leek.png", "Leek", 70.00m, "bunch" },
                    { 9, "Crisp green lettuce, ideal for salads and sandwiches.", "lettuce.png", "Lettuce", 10.20m, "head" },
                    { 10, "Fresh, tangy lime perfect for drinks and cooking.", "lime.png", "Lime", 5.50m, "piece" },
                    { 11, "Sweet and juicy melon, perfect for desserts and snacks.", "melon.png", "Melon", 60.00m, "kg" },
                    { 12, "Savory olives great for salads, pizzas, or snacking.", "olives.png", "Olives", 200.00m, "kg" },
                    { 13, "Citrusy, juicy oranges full of vitamin C.", "orange.png", "Orange", 120.00m, "dozen" },
                    { 14, "Sweet green peas, ideal for stir-fries and soups.", "peas.png", "Peas", 150.00m, "kg" },
                    { 15, "Juicy ripe pears, naturally sweet and refreshing.", "pear.png", "Pear", 10.00m, "piece" },
                    { 16, "Tropical pineapple with sweet and tangy flavor.", "pineapple.png", "Pineapple", 80.00m, "piece" },
                    { 17, "Crisp radishes with a peppery flavor.", "radish.png", "Radish", 30.00m, "bunch" },
                    { 18, "Exotic fruit with juicy, sweet-sour flesh.", "rambutan.png", "Rambutan", 120.00m, "kg" },
                    { 19, "Fresh spinach leaves packed with nutrients.", "spinach.png", "Spinach", 10.80m, "bunch" },
                    { 20, "Mild, slightly sweet turnip great for stews.", "turnip.png", "Turnip", 35.00m, "kg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Image", "Name", "Price", "Unit" },
                values: new object[] { "Fresh, tangy lime perfect for drinks and cooking.", "lime.png", "Lime", 5.50m, "piece" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Image", "Name", "Price", "Unit" },
                values: new object[] { "Crisp green lettuce, ideal for salads and sandwiches.", "lettuce.png", "Lettuce", 10.20m, "head" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Image", "Name", "Price", "Unit" },
                values: new object[] { "Sweet seedless grapes, perfect for snacking.", "grapes.png", "Grapes", 20.50m, "kg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Image", "Name", "Price" },
                values: new object[] { "Fresh spinach leaves packed with nutrients.", "spinach.png", "Spinach", 10.80m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "Image", "Name", "Price", "Unit" },
                values: new object[] { "Juicy ripe pears, naturally sweet and refreshing.", "pear.png", "Pear", 10.00m, "piece" });
        }
    }
}
