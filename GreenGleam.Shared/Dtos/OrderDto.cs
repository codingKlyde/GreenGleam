namespace GreenGleam.Shared.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }

        public string AddressName { get; set; }

        public string Address { get; set; }

        public DateTime Date { get; set; }

        public decimal TotalAmount { get; set; }

        public int TotalItems { get; set; }

        public string? Notes { get; set; }

        public string Status { get; set; }
    }
}