namespace Matedu.DTOs.MaterialDTOs
{
    public class MaterialSearchDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public AuthorSimpleDTO Author { get; set; }
        public TypeSimpleDTO Type { get; set; }
    }
}
