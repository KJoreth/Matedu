namespace Matedu.DTOs.TypeDTOs
{
    public class TypeCreateDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Definition { get; set; }
    }
}
