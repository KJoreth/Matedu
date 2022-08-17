namespace Matedu.DTOs.TypeDTOs
{
    public class TypeEditDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Definition { get; set; }
    }
}
