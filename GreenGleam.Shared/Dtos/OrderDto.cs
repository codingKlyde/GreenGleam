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

        [JsonIgnore]
        public string StatusColor =>
            Status switch
            {
                nameof(OrderStatus.Placed) => "#3B82F6",     // Blue-500 (primary theme color)
                nameof(OrderStatus.Confirmed) => "#10B981",  // Green-500 (success/confirmed)
                nameof(OrderStatus.Shipped) => "#6366F1",    // Indigo-500 (in transit)
                nameof(OrderStatus.Delivered) => "#059669",  // Green-600 (delivered/complete)
                nameof(OrderStatus.Cancelled) => "#EF4444",  // Red-500 (cancelled/error)
                _ => "#6B7280"                               // Gray-500 (fallback/unknown)
            };

        public OrderItemDto[] orderItems { get; set; } = [];
    }
}