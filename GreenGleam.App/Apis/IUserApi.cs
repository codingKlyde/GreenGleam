namespace GreenGleam.App.Apis
{
    [Headers("Authorization: Bearer ")]
    public interface IUserApi
    {
        [Post("/api/users/save-address")]
        Task<ApiResultDto> SaveAddressAsync(AddressDto addressDto);

        [Get("/api/users/addresses")]
        Task<AddressDto[]> GetAddresses();

        [Post("/api/users/change-password")]
        Task<ApiResultDto> ChangePasswordAsync(ChangePasswordDto changePasswordDto);

        [Patch("/api/users/update-profile")]
        Task<ApiResultDto<LoggedInUserDto>> UpdateProfileAsync(UpdateProfileDto updateProfileDto);
    }
}