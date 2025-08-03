namespace GreenGleam.Shared.Dtos
{
    public record PlaceOrderDto(OrderItemSaveDto[] OrderItems, int UserAddressId);
}