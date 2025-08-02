namespace GreenGleam.Api.Data.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required, MaxLength(300)]
        public string ImageUrl { get; set; }

        public decimal Price { get; set; }

        [Required, MaxLength(10)]
        public string Unit { get; set; }
    }
}