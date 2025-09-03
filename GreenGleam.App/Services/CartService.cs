namespace GreenGleam.App.Services
{
    public class CartService
    {
        public List<CartModel> CartItems { get; private set; } = [];
        private LocalDataContext _localDataContext;

        public int Count { get; private set; }
        public decimal TotalAmount => CartItems.Sum(x => x.Total);
        public string CountDisplay => Count < 100 ? $"{Count}" : "99";
        public event Action? CartItemCountChanged;

        public CartService(LocalDataContext localDataContext)
        {
            _localDataContext = localDataContext;
        }

        private void NotifyCartItemCountChanged()
        {
            Count = CartItems.Sum(x => x.Quantity);
            CartItemCountChanged?.Invoke();
        }

        public async Task InitializeCartAsync()
        {
            CartItems = await _localDataContext.GetCartItemsAsync();
            NotifyCartItemCountChanged();
        }

        public async Task AddToCartAsync(ProductDto productDto)
        {
            var cartItem = CartItems.FirstOrDefault(x => x.ProductId == productDto.Id); 
            if (cartItem is null)
            {
                cartItem = CartModel.FromDto(productDto);
                await _localDataContext.AddCartItemAsync(cartItem);
                CartItems.Add(cartItem);
            }
            else
            {
                cartItem.Quantity = productDto.Quantity;
                await _localDataContext.UpdateCartItemAsync(cartItem);
            }

            NotifyCartItemCountChanged();
        }
        public async Task RemoveFromCartAsync(ProductDto productDto)
        {
            var cartItem = CartItems.FirstOrDefault(x => x.ProductId == productDto.Id);
            if (cartItem is null)
                return;
            else
            {
                cartItem.Quantity = productDto.Quantity;

                if (cartItem.Quantity == 0)
                {
                    CartItems.Remove(cartItem);
                    await _localDataContext.DeleteCartItemAsync(cartItem.CartItemId);
                }
                else
                    await _localDataContext.UpdateCartItemAsync(cartItem);
            }
            NotifyCartItemCountChanged();
        }

        public async Task IncreaseCartItemQuantityAsync(CartModel cartModel)
        {
            cartModel.Quantity++;
            await _localDataContext.UpdateCartItemAsync(cartModel);

            NotifyCartItemCountChanged();
        }
        public async Task DecreaseCartItemQuantityAsync(CartModel cartModel)
        {
            cartModel.Quantity--;

            if (cartModel.Quantity == 0)
            {
                CartItems.Remove(cartModel);
                await _localDataContext.DeleteCartItemAsync(cartModel.CartItemId);
            }
            else
                await _localDataContext.UpdateCartItemAsync(cartModel);

            NotifyCartItemCountChanged();
        }
        public async Task RemoveCartItemAsync(CartModel cartModel)
        {
            CartItems.Remove(cartModel);

            NotifyCartItemCountChanged();

            await _localDataContext.DeleteCartItemAsync(cartModel.CartItemId);

            await Snackbar.Make("Item removed").Show();
        }

        public async Task ClearCartAsync()
        {
            if (CartItems.Count == 0)
                return;

            if (await MauiInterop.ConfirmAsync("Are you sure you want to clear your cart?", "Confirmation"))
            {
                CartItems.Clear();
                await _localDataContext.ClearCartsAsync();

                NotifyCartItemCountChanged();

                await Snackbar.Make("Cart cleared").Show();
            }
        }
        public async Task ClearCartAfterOrder()
        {
            CartItems.Clear();
            await _localDataContext.ClearCartsAsync();

            NotifyCartItemCountChanged();
        }
    }
}