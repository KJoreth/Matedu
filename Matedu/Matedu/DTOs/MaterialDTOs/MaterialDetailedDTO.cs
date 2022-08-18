
namespace Matedu.DTOs.MaterialDTOs
{
    public class MaterialDetailedDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public int AverageScore { get; set; }
        public AuthorSimpleDTO Author { get; set; }
        public TypeSimpleDTO Type { get; set; }
        public List<ReviewSimpleDTO> Reviews { get; set; }
    }
}
