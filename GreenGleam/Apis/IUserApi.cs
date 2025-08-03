namespace GreenGleam.Apis
{
    [Headers("Authorization: Bearer ")]
    public interface IUserApi
    {
        [Post("/api/user/save-address")]
        Task<ApiResultDto> SaveAddressAsync(AddressDto addressDto);

        [Get("/api/user/addresses")]
        Task<AddressDto[]> GetAddresses();

        [Post("/api/user/change-password")]
        Task<ApiResultDto> ChangePasswordAsync(ChangePasswordDto changePasswordDto);
    }
}