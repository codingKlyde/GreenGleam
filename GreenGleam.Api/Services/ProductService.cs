namespace GreenGleam.Api.Services
{
    public class ProductService
    {
        private readonly DataContext _dataContext;

        public  ProductService (DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<ProductDto[]> GetProductsAsync() => await _dataContext.Products
            .AsNoTracking()
            .Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Image = p.Image,
                Description = p.Description,
                Price = p.Price,
                Unit = p.Unit
            })
            .ToArrayAsync();
    }
}