namespace GreenGleam.App.Services
{
    public class CartService
    {
        public List<CartModel> CartItems { get; private set; } = [];
        public int Count { get; private set; }
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
        public void RemoveCartItem(CartModel cartModel)
        {
            CartItems.Remove(cartModel);
            NotifyCartItemCountChanged();
        }
        public async Task ClearCartAsync()
        {
            if (CartItems.Count == 0)
                return;

            if (await App.Current.Windows[0].Page.DisplayAlert("Confirmation", "Clear cart?", "Yes", "No"))
            {
                CartItems.Clear();
                NotifyCartItemCountChanged();
            }
        }
    }
}