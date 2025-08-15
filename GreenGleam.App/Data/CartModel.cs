namespace GreenGleam.App.Data
{
    // It is used for the cart functionality in the app
    public class CartModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Unit { get; set; }
        public int Quantity { get; set; }

        public static CartModel FromDto(ProductDto productDto)
        {
            return new CartModel
            {
                Name = productDto.Name,
                Image = productDto.Image,
                Description = productDto.Description,
                Price = productDto.Price,
                Unit = productDto.Unit,
                Quantity = productDto.Quantity
            };
        }
    }
}