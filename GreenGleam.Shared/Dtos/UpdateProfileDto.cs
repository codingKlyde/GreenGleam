namespace GreenGleam.Shared.Dtos
{
    public class UpdateProfileDto
    {
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string? MobileNumber { get; set; }
    }
}