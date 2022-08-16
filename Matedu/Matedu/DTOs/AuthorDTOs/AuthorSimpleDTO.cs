namespace Matedu.DTOs.AuthorDTOs
{
    public record AuthorSimpleDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MaterialCounter { get; set; }
    }
}
