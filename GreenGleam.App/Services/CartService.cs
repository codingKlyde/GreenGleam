namespace GreenGleam.App.Services
{
    public class CartService
    {
        public List<ProductDto> CartItems { get; private set; } = [];
        public int Count { get; private set; }
        public string CountDisplay => Count < 100 ? $"{Count}" : "99";

        public event Action? CartItemCountChanged;

        public void AddToCart(ProductDto product)
        {
            Count++;
            CartItemCountChanged?.Invoke();
        }

        public void RemoveFromCart(ProductDto product)
        {
            Count--;
            CartItemCountChanged?.Invoke();
        }
    }
}