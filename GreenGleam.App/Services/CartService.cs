namespace GreenGleam.App.Services
{
    public class CartService
    {
        public List<CartModel> CartItems { get; private set; } = [];
        public int Count { get; private set; }
        public decimal TotalAmount => CartItems.Sum(x => x.Total);
        public string CountDisplay => Count < 100 ? $"{Count}" : "99";

        public event Action? CartItemCountChanged;

        private void NotifyCartItemCountChanged()
        {
            Count = CartItems.Sum(x => x.Quantity);
            CartItemCountChanged?.Invoke();
        }

        public void AddToCart(ProductDto productDto)
        {
            var cartItem = CartItems.FirstOrDefault(x => x.ProductId == productDto.Id); 
            if (cartItem is null)
            {
                cartItem = CartModel.FromDto(productDto);
                CartItems.Add(cartItem);
            }
            else
                cartItem.Quantity = productDto.Quantity;

            NotifyCartItemCountChanged();
        }
        public void RemoveFromCart(ProductDto productDto)
        {
            var cartItem = CartItems.FirstOrDefault(x => x.ProductId == productDto.Id);
            if (cartItem is null)
                return;
            else
            {
                cartItem.Quantity = productDto.Quantity;

                if (cartItem.Quantity == 0)
                    CartItems.Remove(cartItem);
            }
            NotifyCartItemCountChanged();
        }

        public void IncreaseCartItemQuantity(CartModel cartModel)
        {
            cartModel.Quantity++;

            NotifyCartItemCountChanged();
        }
        public void DecreaseCartItemQuantity(CartModel cartModel)
        {
            cartModel.Quantity--;

            if (cartModel.Quantity == 0)
                CartItems.Remove(cartModel);

            NotifyCartItemCountChanged();
        }
        public async void RemoveCartItem(CartModel cartModel)
        {
            CartItems.Remove(cartModel);
            NotifyCartItemCountChanged();

            await Snackbar.Make("Item removed").Show();
        }
        public async Task ClearCartAsync()
        {
            if (CartItems.Count == 0)
                return;

            if (await MauiInterop.ConfirmAsync("Are you sure you want to clear your cart?", "Confirmation"))
            {
                CartItems.Clear();
                NotifyCartItemCountChanged();

                await Snackbar.Make("Cart cleared").Show();
            }
        }
    }
}