namespace GreenGleam.Api.Endpoints
{
    public static class UserEndpoints
    {
        public static IEndpointRouteBuilder MapUserEndpoints(this IEndpointRouteBuilder endpointRoute)
        {
            var userGroup = endpointRoute.MapGroup("/api/users").RequireAuthorization().WithTags("User");

            userGroup.MapPost("/addresses", async (AddressDto addressDto, UserService userService, ClaimsPrincipal claimsPrincipal) =>
            {
                return Results.Ok(await userService.SaveAddressAsync(addressDto, claimsPrincipal.GetUserId()));
            })
            .Produces<ApiResultDto>()
            .WithName("Save-Address");

            userGroup.MapGet("/addresses", async (UserService userService, ClaimsPrincipal claimsPrincipal) =>
            {
                return Results.Ok(await userService.GetAddresses(claimsPrincipal.GetUserId()));
            })
           .Produces<AddressDto[]>()
           .WithName("Get-Addresses");

            userGroup.MapPost("/change-password", async (ChangePasswordDto changePasswordDto, UserService userService, ClaimsPrincipal claimsPrincipal) =>
            {
                return Results.Ok(await userService.ChangePasswordAsync(changePasswordDto, claimsPrincipal.GetUserId()));
            })
           .Produces<ApiResultDto>()
           .WithName("Change-Password");

            return endpointRoute;
        }
    }
}