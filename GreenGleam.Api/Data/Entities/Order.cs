namespace GreenGleam.Api.Data.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public string Address { get; set; }

        public DateTime Date { get; set; }

        public decimal TotalAmount { get; set; }

        [Required, MaxLength(500)]
        public string? Notes { get; set; }

        [Required, MaxLength(15)]
        public string Status { get; set; } = nameof(OrderStatus.Placed);


        public int UserId { get; set; }
        public virtual User User { get; set; }


        public int UserAddressId { get; set; }


        public virtual ICollection<OrderItem> OderItems { get; set; } = [];
    }
}