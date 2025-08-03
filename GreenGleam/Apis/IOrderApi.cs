namespace GreenGleam.Apis
{
    [Headers("Authorization: Bearer ")]
    public interface IOrderApi
    {
        [Post("/api/orders/place-order")]
        Task<ApiResultDto> PlaceOrderAsync(PlaceOrderDto placeOrderDto);

        [Get("/api/orders/user/{userId}")]
        Task<OrderDto[]> GetOrdersAsync(int startIndex, int pageSize, int userId);

        [Get("/api/orders/user/{userId}/orders/{orderId}/items")]
        Task<ApiResultDto<OrderItemDto[]>> GetOrderItemsAsync(int orderId, int userId);
    }
}