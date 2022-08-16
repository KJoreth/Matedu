namespace Matedu.DTOs.AuthorDTOs
{
    public class AuthorCreateDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
