namespace GreenGleam.Shared.Dtos
{
    public record LoggedInUserDto(
        int Id,
        string Name,
        string Email,
        string? MobileNumber,
        string Token);
}