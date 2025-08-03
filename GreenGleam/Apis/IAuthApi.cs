namespace GreenGleam.Apis
{
    public interface IAuthApi
    {
        [Post("/api/auth/register")]
        Task<ApiResultDto> RegisterAsync(RegisterDto registerDto);

        [Post("/api/auth/login")]
        Task<ApiResultDto<LoggedInUserDto>> LoginAsync(LoginDto loginDto);
    }
}