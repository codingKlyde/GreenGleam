namespace GreenGleam.Apis
{
    public interface IProductApi
    {
        [Get("/api/products")]
        Task<ProductDto[]> GetProductsAsync();
    }
}