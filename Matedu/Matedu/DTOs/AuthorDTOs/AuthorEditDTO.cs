namespace Matedu.DTOs.AuthorDTOs
{
    public class AuthorEditDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
