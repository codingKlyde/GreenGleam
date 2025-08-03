namespace GreenGleam.Api.Data.Entities
{
    public class OrderItem
    {
        [Key]
        public long Id { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProducImage { get; set; }
        public string ProductPrice { get; set; }

        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}