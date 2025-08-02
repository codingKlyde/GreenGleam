namespace GreenGleam.Api.Data.Entities
{
    public class User
    {
        [Key]
        public int  Id { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [Required, MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(50)]
        public string MobileNumber { get; set; }
        [Required]
        public string PasswordHash { get; set; }

        public ICollection<UserAddress> UserAddresses { get; set; } = [];
    }
}