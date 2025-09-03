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

        public string ProductImage { get; set; }

        public decimal ProductPrice { get; set; }


        public decimal Amount => Quantity * ProductPrice;

    }
}