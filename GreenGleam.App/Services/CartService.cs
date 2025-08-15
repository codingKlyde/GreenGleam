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
            if (cartItem != null)
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
            if (cartItem != null)
                return;
            else
            {
                cartItem.Quantity = productDto.Quantity;

                if (cartItem.Quantity == 0)
                    CartItems.Remove(cartItem);
            }

            NotifyCartItemCountChanged();
        }
    }
}