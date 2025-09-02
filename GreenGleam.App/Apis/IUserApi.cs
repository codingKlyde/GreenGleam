namespace GreenGleam.App.Apis
{
    [Headers("Authorization: Bearer ")]
    public interface IUserApi
    {

        [Get("/api/users/get-addresses")]
        Task<AddressDto[]> GetAddressesAsync();

        [Post("/api/users/save-address")]
        Task<ApiResultDto> SaveAddressAsync(AddressDto addressDto);

        [Delete("/api/users/{addressId}")]
        Task<ApiResultDto> DeleteAddressAsync(int addressId);

        [Post("/api/users/change-password")]
        Task<ApiResultDto> ChangePasswordAsync(ChangePasswordDto changePasswordDto);

        [Patch("/api/users/update-profile")]
        Task<ApiResultDto<LoggedInUserDto>> UpdateProfileAsync(UpdateProfileDto updateProfileDto);
    }
}