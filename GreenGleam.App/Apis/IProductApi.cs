namespace GreenGleam.App.Apis
{
    public interface IProductApi
    {
        [Get("/api/products")]
        Task<ProductDto[]> GetProductsAsync();
    }
}