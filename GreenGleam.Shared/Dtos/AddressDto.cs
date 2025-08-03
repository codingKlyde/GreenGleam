namespace GreenGleam.Shared.Dtos
{
    public class AddressDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public bool isDefault { get; set; }
    }
}