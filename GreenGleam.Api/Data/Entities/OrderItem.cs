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
        public string ProductImage { get; set; }
        [Column(TypeName = "DECIMAL(18, 2)")]
        public decimal ProductPrice { get; set; }

        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}