namespace GreenGleam.Api.Endpoints
{
    public static class UserEndpoints
    {
        public static IEndpointRouteBuilder MapUserEndpoints(this IEndpointRouteBuilder endpointRoute)
        {
            var userGroup = endpointRoute.MapGroup("/api/users").RequireAuthorization().WithTags("User");

            userGroup.MapGet("/get-addresses", async (UserService userService, ClaimsPrincipal claimsPrincipal) =>
            {
                return Results.Ok(await userService.GetAddressesAsync(claimsPrincipal.GetUserId()));
            })
            .Produces<AddressDto[]>()
            .WithName("Get-Addresses");

            userGroup.MapPost("/save-address", async (AddressDto addressDto, UserService userService, ClaimsPrincipal claimsPrincipal) =>
            {
                return Results.Ok(await userService.SaveAddressAsync(addressDto, claimsPrincipal.GetUserId()));
            })
            .Produces<ApiResultDto>()
            .WithName("Save-Address");

            userGroup.MapDelete("/{addressId}", async (int addressId, UserService userService, ClaimsPrincipal claimsPrincipal) =>
            {
                return Results.Ok(await userService.DeleteAddressAsync(addressId, claimsPrincipal.GetUserId()));
            })
            .Produces<ApiResultDto>()
            .WithName("Delete-Address");

            userGroup.MapPost("/change-password", async (ChangePasswordDto changePasswordDto, UserService userService, ClaimsPrincipal claimsPrincipal) =>
            {
                return Results.Ok(await userService.ChangePasswordAsync(changePasswordDto, claimsPrincipal.GetUserId()));
            })
           .Produces<ApiResultDto>()
           .WithName("Change-Password");

            userGroup.MapPatch("/update-profile", async (UpdateProfileDto updateProfileDto, UserService userService, ClaimsPrincipal claimsPrincipal) =>
            {
                return Results.Ok(await userService.UpdateProfileAsync(updateProfileDto, claimsPrincipal.GetUserId()));
            })
            .Produces<ApiResultDto<LoggedInUserDto>>()
            .WithName("Update-Profile");

            return endpointRoute;
        }
    }
}