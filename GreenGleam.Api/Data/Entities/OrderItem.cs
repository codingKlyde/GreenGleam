namespace GreenGleam.Api.Data.Entities
{
    public class OrderItem
    {
        [Key]
        public long Id { get; set; }

        public int Qunatity { get; set; }

        public string Unit { get; set; }


        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProducImageUrl { get; set; }

        public string ProductPrice { get; set; }


        public string OrderId { get; set; }

        public virtual Order Order { get; set; }
    }
}