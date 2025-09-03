namespace GreenGleam.App.Data
{
    public class LocalDataContext : IAsyncDisposable
    {
        private const string DatabaseName = "test";
        private readonly SQLiteAsyncConnection _dbConnection;

        public LocalDataContext()
        {
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, DatabaseName);
            _dbConnection = new SQLiteAsyncConnection(dbPath, SQLiteOpenFlags.Create | SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.SharedCache);
        }

        public async Task InitializeDatabaseAsync() => await _dbConnection.CreateTableAsync<CartModel>();
        public async Task<List<CartModel>> GetCartItemsAsync() => await _dbConnection.Table<CartModel>().ToListAsync();
        public async Task AddCartItemAsync(CartModel cartModel) => await _dbConnection.InsertAsync(cartModel);
        public async Task UpdateCartItemAsync(CartModel cartModel) => await _dbConnection.UpdateAsync(cartModel);
        public async Task DeleteCartItemAsync(int cartItemId) => await _dbConnection.DeleteAsync<CartModel>(cartItemId);
        public async Task ClearCartsAsync() => await _dbConnection.DeleteAllAsync<CartModel>();

        public async ValueTask DisposeAsync()
        {
            if (_dbConnection is not null)
                await _dbConnection.CloseAsync();
        } 
    }
}