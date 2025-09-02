namespace GreenGleam.Api.Endpoints
{
    public static class OrderEndpoints
    {
        public static IEndpointRouteBuilder MapOrderEndpoints(this IEndpointRouteBuilder endpointRoute)
        {
            var orderGroup = endpointRoute.MapGroup("/api/orders").RequireAuthorization().WithTags("Orders");

            orderGroup.MapPost("/place-order", async (PlaceOrderDto placeOrderDto, OrderService orderService, ClaimsPrincipal claimsPrincipal) =>
            {
                return Results.Ok(await orderService.PlaceOrderAsync(placeOrderDto, claimsPrincipal.GetUserId()));
            })
            .Produces<ApiResultDto>()
            .WithName("Place-Order");

            orderGroup.MapGet("/user/{userId:int}", async (OrderService orderService, ClaimsPrincipal claimsPrincipal, int startIndex, int pageSize, int userId) =>
            {
                if (userId != claimsPrincipal.GetUserId())
                    return Results.Unauthorized();

                return Results.Ok(await orderService.GetOrdersAsync(startIndex, pageSize, claimsPrincipal.GetUserId()));
            })
            .Produces<OrderDto[]>()
            .WithName("Get-Orders");

            orderGroup.MapGet("/user/{userId:int}/orders/{orderId:int}/items", async (OrderService orderService, ClaimsPrincipal claimsPrincipal, int userId, int orderId) =>
            {
                if (userId != claimsPrincipal.GetUserId())
                    return Results.Unauthorized();

                return Results.Ok(await orderService.GetOrderItemsAsync(claimsPrincipal.GetUserId(), orderId));
            })
           .Produces<OrderItemDto[]>()
           .WithName("Get-Order-Items");

            return endpointRoute;
        }
    }
}