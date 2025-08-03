namespace GreenGleam.Api.Services
{
    public class AuthService
    {
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly DataContext _dataContext;

        public AuthService(IPasswordHasher<User> passwordHasher, DataContext dataContext)
        {
            _passwordHasher = passwordHasher;
            _dataContext = dataContext;
        }

        public async Task<ApiResultDto> RegisterAsync(RegisterDto registerDto)
        {
            if (await _dataContext.Users.AnyAsync(u => u.Email == registerDto.Email))
                return ApiResultDto.Fail("Email already exists");

            var user = new User
            {
                Name = registerDto.Name,
                Email = registerDto.Email,
                MobileNumber = registerDto.MobileNumber
            };

            user.PasswordHash = _passwordHasher.HashPassword(user, registerDto.Password);

            try
            {
                _dataContext.Users.Add(user);
                await _dataContext.SaveChangesAsync();
                return ApiResultDto.Success();
            }
            catch (Exception ex)
            {
                return ApiResultDto.Fail(ex.Message);
            }
        }

        public async Task<ApiResultDto<LoggedInUserDto>> LoginAsync(LoginDto loginDto)
        {
            var user = await _dataContext.Users.FirstOrDefaultAsync(u => u.Email == loginDto.Email);
            if (user is null)
                return ApiResultDto<LoggedInUserDto>.Fail("User does not exist");

            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, loginDto.Password);
            if (result != PasswordVerificationResult.Success)
                return ApiResultDto<LoggedInUserDto>.Fail("Incorrect password");

            var jwt = "";
            var loggedInUser = new LoggedInUserDto(user.Id, user.Name, user.Email, jwt);

            return ApiResultDto<LoggedInUserDto>.Success(loggedInUser);
        } 
    }
}