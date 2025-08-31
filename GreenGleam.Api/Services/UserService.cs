namespace GreenGleam.Api.Services
{
    public class UserService
    {
        private readonly DataContext _dataContext;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly TokenService _tokenService;


        public UserService(DataContext dataContext, IPasswordHasher<User> passwordHasher, TokenService tokenService)
        {
            _dataContext = dataContext;
            _passwordHasher = passwordHasher;
            _tokenService = tokenService;
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

        public async Task<ApiResultDto> ChangePasswordAsync(ChangePasswordDto changePasswordDto, int userId)
        {
            try
            {
                var user = await _dataContext.Users.FindAsync(userId);
                if (user is null)
                    return ApiResultDto.Fail("User does not exist");

                var verification = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, changePasswordDto.CurrentPassword);
                if (verification != PasswordVerificationResult.Success)
                    return ApiResultDto.Fail("Incorrect password");

                user.PasswordHash = _passwordHasher.HashPassword(user, changePasswordDto.NewPassword);

                _dataContext.Users.Update(user);
                await _dataContext.SaveChangesAsync();

                return ApiResultDto.Success();
            }
            catch (Exception ex) 
            {
                return ApiResultDto.Fail(ex.Message);
            }
        }

        public async Task<ApiResultDto<LoggedInUserDto>> UpdateProfileAsync(UpdateProfileDto updateProfileDto, int userId)
        {
            try
            {
                var user = await _dataContext.Users.FindAsync(userId);
                if (user is null)
                    return ApiResultDto<LoggedInUserDto>.Fail("User does not exist");

                user.Name = updateProfileDto.Name;
                user.MobileNumber = updateProfileDto.MobileNumber;

                await _dataContext.SaveChangesAsync();

                var jwt = _tokenService.GenerateJwtToken(user);
                var loggedInUser = new LoggedInUserDto(user.Id, user.Name, user.Email, user.MobileNumber, jwt);

                return ApiResultDto<LoggedInUserDto>.Success(loggedInUser);
            }
            catch (Exception ex)
            {
                return ApiResultDto<LoggedInUserDto>.Fail(ex.Message);
            }
        }
    }
}