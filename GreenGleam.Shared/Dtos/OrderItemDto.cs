namespace GreenGleam.Shared.Dtos
{
    public class OrderItemDto
    {
        public long Id { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProducImage { get; set; }
        public string ProductPrice { get; set; }
    }
}