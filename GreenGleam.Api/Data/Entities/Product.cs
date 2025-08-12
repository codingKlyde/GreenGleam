namespace GreenGleam.Api.Data.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [Required, MaxLength(300)]
        public string Image { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "DECIMAL(18, 2)")]
        public decimal Price { get; set; }
        [Required, MaxLength(15)]
        public string Unit { get; set; }

        public static Product[] GetSeedData()
        {
            Product[] products =
            [
                new() { Id = 1, Name = "Blueberry", Image = "image/product/blueberry.png", Description = "Sweet and tart blueberries packed with antioxidants.", Price = 250.00m, Unit = "kg" },
                new() { Id = 2, Name = "Carrot", Image = "image/product/carrot.png", Description = "Crunchy carrots full of vitamins and nutrients.", Price = 50.00m, Unit = "kg" },
                new() { Id = 3, Name = "Corn", Image = "image/product/corn.png", Description = "Sweet golden corn on the cob, ready to boil or grill.", Price = 20.00m, Unit = "piece" },
                new() { Id = 4, Name = "Dill", Image = "image/product/dill.png", Description = "Fresh dill herb for seasoning and garnishing.", Price = 25.00m, Unit = "bunch" },
                new() { Id = 5, Name = "Eggplant", Image = "image/product/eggplant.png", Description = "Fresh eggplant perfect for grilling or stir-frying.", Price = 40.00m, Unit = "kg" },
                new() { Id = 6, Name = "Garlic", Image = "image/product/garlic.png", Description = "Aromatic garlic bulbs, essential for cooking.", Price = 80.00m, Unit = "kg" },
                new() { Id = 7, Name = "Grapes", Image = "image/product/grapes.png", Description = "Sweet seedless grapes, perfect for snacking.", Price = 20.50m, Unit = "kg" },
                new() { Id = 8, Name = "Leek", Image = "image/product/leek.png", Description = "Fresh leeks with mild onion-like flavor.", Price = 70.00m, Unit = "bunch" },
                new() { Id = 9, Name = "Lettuce", Image = "image/product/lettuce.png", Description = "Crisp green lettuce, ideal for salads and sandwiches.", Price = 10.20m, Unit = "head" },
                new() { Id = 10, Name = "Lime", Image = "image/product/lime.png", Description = "Fresh, tangy lime perfect for drinks and cooking.", Price = 5.50m, Unit = "piece" },
                new() { Id = 11, Name = "Melon", Image = "image/product/melon.png", Description = "Sweet and juicy melon, perfect for desserts and snacks.", Price = 60.00m, Unit = "kg" },
                new() { Id = 12, Name = "Olives", Image = "image/product/olives.png", Description = "Savory olives great for salads, pizzas, or snacking.", Price = 200.00m, Unit = "kg" },
                new() { Id = 13, Name = "Orange", Image = "image/product/orange.png", Description = "Citrusy, juicy oranges full of vitamin C.", Price = 120.00m, Unit = "dozen" },
                new() { Id = 14, Name = "Peas", Image = "image/product/peas.png", Description = "Sweet green peas, ideal for stir-fries and soups.", Price = 150.00m, Unit = "kg" },
                new() { Id = 15, Name = "Pear", Image = "image/product/pear.png", Description = "Juicy ripe pears, naturally sweet and refreshing.", Price = 10.00m, Unit = "piece" },
                new() { Id = 16, Name = "Pineapple", Image = "image/product/pineapple.png", Description = "Tropical pineapple with sweet and tangy flavor.", Price = 80.00m, Unit = "piece" },
                new() { Id = 17, Name = "Radish", Image = "image/product/radish.png", Description = "Crisp radishes with a peppery flavor.", Price = 30.00m, Unit = "bunch" },
                new() { Id = 18, Name = "Rambutan", Image = "image/product/rambutan.png", Description = "Exotic fruit with juicy, sweet-sour flesh.", Price = 120.00m, Unit = "kg" },
                new() { Id = 19, Name = "Spinach", Image = "image/product/spinach.png", Description = "Fresh spinach leaves packed with nutrients.", Price = 10.80m, Unit = "bunch" },
                new() { Id = 20, Name = "Turnip", Image = "image/product/turnip.png", Description = "Mild, slightly sweet turnip great for stews.", Price = 35.00m, Unit = "kg" }
            ];

            return products;
        }
    }
}