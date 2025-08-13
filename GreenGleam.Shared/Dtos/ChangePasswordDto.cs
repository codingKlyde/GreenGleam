using System.Text.Json.Serialization;

namespace GreenGleam.Shared.Dtos
{
    public class ChangePasswordDto
    {
        [Required]
        public string CurrentPassword { get; set; }

        [Required]
        public string NewPassword { get; set; }

        [Required, Compare(nameof(NewPassword))]
        [JsonIgnore]
        public string ConfirmNewPassword { get; set; }
    }
}