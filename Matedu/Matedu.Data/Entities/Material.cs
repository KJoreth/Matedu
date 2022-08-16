namespace Matedu.Data.Entities
{
    public class Material
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public DateTime PublishDate { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public int TypeId { get; set; }
        public MaterialType Type { get; set; }
        public List<Review> Reviews { get; set; } = new List<Review>();
        public int AverageScore
        {
            get
            {
                if (Reviews.Count == 0)
                    return 0;

                int score = 0;
                foreach (Review review in Reviews)
                    score += review.Points;
                return score / Reviews.Count;
            }
        }

    }
}
