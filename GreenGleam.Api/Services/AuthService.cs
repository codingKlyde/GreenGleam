namespace GreenGleam.Api.Services
{
    public class AuthService
    {
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly DataContext _dataContext;
        private readonly TokenService _tokenService;

        public AuthService(DataContext dataContext, IPasswordHasher<User> passwordHasher, TokenService tokenService)
        {
            _dataContext = dataContext;
            _passwordHasher = passwordHasher;
            _tokenService = tokenService;
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

            var jwt = _tokenService.GenerateJwtToken(user);
            var loggedInUser = new LoggedInUserDto(user.Id, user.Name, user.Email, user.MobileNumber, jwt);

            return ApiResultDto<LoggedInUserDto>.Success(loggedInUser);
        }
    }
}