namespace GreenGleam.Api.Services
{
    public class UserService
    {
        private readonly DataContext _dataContext;

        public UserService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<ApiResultDto> SaveAddressAsync(AddressDto addressDto, int userId)
        {
            UserAddress? userAddress = null;
            if (addressDto.Id == 0)
            {
                userAddress = new UserAddress
                {
                    Id = addressDto.Id,
                    Name = addressDto.Name,
                    Address = addressDto.Address,
                    IsDefault = addressDto.isDefault,

                    UserId = userId
                };

                _dataContext.UserAddresses.Add(userAddress);
            }
            else
            {
                userAddress = await _dataContext.UserAddresses.FindAsync(addressDto.Id);
                if (userAddress is null)
                    return ApiResultDto.Fail("Invalid request");

                userAddress.Name = addressDto.Name;
                userAddress.Address = addressDto.Address;
                userAddress.IsDefault = addressDto.isDefault;

                _dataContext.UserAddresses.Update(userAddress);
            }

            try
            {
                if (addressDto.isDefault)
                {
                    var defaultAddress = await _dataContext.UserAddresses.FirstOrDefaultAsync(d => d.UserId == userId && d.IsDefault && d.Id != addressDto.Id);
                    if (defaultAddress is not null)
                        defaultAddress.IsDefault = false;
                }

                await _dataContext.SaveChangesAsync();
                return ApiResultDto.Success();
            }
            catch (Exception ex)
            {
                return ApiResultDto.Fail(ex.Message);
            }
        }

        public async Task<AddressDto[]> GetAddresses(int userId) => await _dataContext.UserAddresses
            .AsTracking()
            .Where(a => a.Id == userId)
            .Select(a => new AddressDto
            {
                Id = a.Id,
                Name = a.Name,
                Address = a.Address,
                isDefault = a.IsDefault
            })
            .ToArrayAsync();
    }
}