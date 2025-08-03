namespace GreenGleam.Api.Endpoints
{
    public static class ProductEndpoints
    {
        public static IEndpointRouteBuilder MapProductEndpoints(this IEndpointRouteBuilder endpointRoute)
        {
            endpointRoute.MapGet("/api/products", async (ProductService productService) => 
                Results.Ok(await productService.GetProductsAsync()))
                .Produces<ProductDto[]>()
                .WithName("Products");

            return endpointRoute;
        }
    }
}