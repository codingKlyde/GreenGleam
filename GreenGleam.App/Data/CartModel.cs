namespace GreenGleam.App.Data
{
    public class CartModel
    {
        [PrimaryKey, AutoIncrement]
        public int CartItemId { get; set; }
        public int ProductId { get; set; }

        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Unit { get; set; }
        public int Quantity { get; set; }
        [Ignore]
        public decimal Total => Quantity * Price;

        public static CartModel FromDto(ProductDto productDto)
        {
            return new CartModel
            {
                Name = productDto.Name,
                Image = productDto.Image,
                Description = productDto.Description,
                Price = productDto.Price,
                Unit = productDto.Unit,
                Quantity = productDto.Quantity,

                ProductId = productDto.Id
            };
        }
    }
}