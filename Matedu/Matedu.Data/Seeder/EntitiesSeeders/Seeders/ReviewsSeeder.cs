namespace Matedu.Data.Seeder.EntitiesSeeders.Seeders
{
    public static class ReviewsSeeder
    {
        public static void SeedRevies(this ModelBuilder builder)
        {
            List<Review> reviews = new List<Review>();
            string[] fileLines = File.ReadAllLines("../Matedu.Data/Seeder/EntitiesSeeders/Data/Reviews.txt");
            foreach (string line in fileLines.Skip(1))
            {
                var item = GetItemFromLine(line);
                reviews.Add(item);
            }

            builder.Entity<Review>().HasData(reviews);
        }

        private static Review GetItemFromLine(string line)
        {
            string[] item = line.Split('|');
            int id = Convert.ToInt32(item[0]);
            int materialId = Convert.ToInt32(item[1]);
            string text = item[2];
            int points = Convert.ToInt32(item[3]);
            return new Review() { Id = id, MaterialId = materialId, Text = text, Points = points };
        }
    }
}
