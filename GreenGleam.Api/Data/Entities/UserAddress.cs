namespace GreenGleam.Api.Data.Entities
{
    public class UserAddress
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [Required, MaxLength(500)]
        public string Address { get; set; }
        public bool IsDefault { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}