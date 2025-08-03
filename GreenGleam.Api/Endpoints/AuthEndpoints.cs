namespace GreenGleam.Api.Endpoints
{
    public static class AuthEndpoints
    {
        public static IEndpointRouteBuilder MapAuthEndpoints(this IEndpointRouteBuilder endpointRoute)
        {
            var authGroup = endpointRoute.MapGroup("/api/auth").WithTags("Auth");

            authGroup.MapPost("/register", async (RegisterDto registerDto, AuthService athService) =>
            {
                return Results.Ok(await athService.RegisterAsync(registerDto));
            })
            .Produces<ApiResultDto>()
            .WithName("Register");

            authGroup.MapPost("/login", async (LoginDto loginDto, AuthService athService) =>
            {
                return Results.Ok(await athService.LoginAsync(loginDto));
            })
           .Produces<ApiResultDto<LoggedInUserDto>>()
           .WithName("Login");

            return endpointRoute;
        }
    }
}