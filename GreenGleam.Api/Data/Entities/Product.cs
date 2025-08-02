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
                new() { Id = 1, Name = "Lime", Image = "lime.png", Description = "Fresh, tangy lime perfect for drinks and cooking.", Price = 5.50m, Unit = "piece" },
                new() { Id = 2, Name = "Lettuce", Image = "lettuce.png", Description = "Crisp green lettuce, ideal for salads and sandwiches.", Price = 10.20m, Unit = "head" },
                new() { Id = 3, Name = "Grapes", Image = "grapes.png", Description = "Sweet seedless grapes, perfect for snacking.", Price = 20.50m, Unit = "kg" },
                new() { Id = 4, Name = "Spinach", Image = "spinach.png", Description = "Fresh spinach leaves packed with nutrients.", Price = 10.80m, Unit = "bunch" },
                new() { Id = 5, Name = "Pear", Image = "pear.png", Description = "Juicy ripe pears, naturally sweet and refreshing.", Price = 10.00m, Unit = "piece" }
            ];

            return products;
        }
    }
}