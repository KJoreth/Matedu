namespace Matedu.DTOs.ReviewDTOs
{
    public class ReviewDetailedDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Points { get; set; }
        public string Username { get; set; }
        public MaterialSimpleDTO Material { get; set; }
    }
}
