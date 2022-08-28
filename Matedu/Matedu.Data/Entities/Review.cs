namespace Matedu.Data.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public int MaterialId { get; set; }
        public Material Material { get; set; }
        public string UserName { get; set; }
        public string Text { get; set; }
        public int Points { get; set; }
    }
}
