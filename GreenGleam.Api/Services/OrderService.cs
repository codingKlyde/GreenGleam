namespace GreenGleam.Api.Services
{
    public class OrderService
    {
        private readonly DataContext _dataContext;

        public OrderService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<ApiResultDto> PlaceOrderAsync(PlaceOrderDto placeOrderDto, int userId)
        {
            if (placeOrderDto.OrderItems.Length == 0)
                return ApiResultDto.Fail("Order must contain atleast one item");

            var productIds = placeOrderDto.OrderItems
                .Select(o => o.ProductId)
                .ToHashSet();

            var products = await _dataContext.Products
                .Where(p => productIds.Contains(p.Id))
                .ToDictionaryAsync(p => p.Id);

            if (products.Count == placeOrderDto.OrderItems.Length)
                return ApiResultDto.Fail("Some product is not available");

            var oderItems = placeOrderDto.OrderItems
                .Select(o => new OrderItem
                {
                    ProductId = o.ProductId,
                    ProductName = products[o.ProductId].Name,
                    ProducImage = products[o.ProductId].Image,
                    ProductDescription = products[o.ProductId].Description,
                    ProductPrice = products[o.ProductId].Price,
                    Quantity = o.Quantity,

                })
                .ToArray();

            var order = new Order
            {
                UserId = userId,
                Date = DateTime.UtcNow,
                UserAddressId = placeOrderDto.UserAddressId,
                AddressName = placeOrderDto.AddressName,
                Address = placeOrderDto.Address,
                TotalItems = placeOrderDto.OrderItems.Length,
                TotalAmount = oderItems.Sum(sum => sum.Quantity * sum.ProductPrice),
                OderItems = oderItems
            };

            try
            {
                _dataContext.Orders.Add(order);
                await _dataContext.SaveChangesAsync();
                return ApiResultDto.Success();
            }
            catch (Exception ex)
            {
                return ApiResultDto.Fail(ex.Message);
            }
        }

        public async Task<AddressDto[]> GetOrdersAsync(int startIndex, int pageSize, int userId) =>
             await _dataContext.UserAddresses
                .AsNoTracking()
                .Where(a => a.UserId == userId)
                .OrderByDescending(order => order.Id)
                .Skip(startIndex)
                .Take(pageSize)
                .Select(select => new AddressDto
                {
                    Id = select.Id,
                    Name = select.Name,
                    Address = select.Address,
                    isDefault = select.IsDefault
                })
                .ToArrayAsync();

        public async Task<ApiResultDto<OrderItemDto[]>> GetOrderItemsAsync(int orderId, int userId)
        {
            var checkOrder = await _dataContext.Orders
                .AsNoTracking()
                .Include(o => o.OderItems)
                .FirstOrDefaultAsync(o => o.Id == orderId);

            if (checkOrder is null)
                return ApiResultDto<OrderItemDto[]>.Fail("Order is not found");

            if (checkOrder.UserId != userId)
                return ApiResultDto<OrderItemDto[]>.Fail("Order is not found in your account");

            var getOrder = checkOrder.OderItems
                .Select(o => new OrderItemDto
                {
                    Id = o.Id,
                    ProductId = o.ProductId,
                    ProductName = o.ProductName,
                    ProducImage = o.ProducImage,
                    ProductDescription = o.ProductDescription,
                    Quantity = o.Quantity,
                    Unit = o.Unit,
                })
                .ToArray();

            return ApiResultDto<OrderItemDto[]>.Success(getOrder);
        }
    }
}