namespace Matedu.Data.Seeder.EntitiesSeeders.Seeders
{
    public static class AuthorsSeeder
    {
        public static void SeedAuthors(this ModelBuilder builder)
        {
            List<Author> authors = new List<Author>();
            string[] fileLines = File.ReadAllLines("../Matedu.Data/Seeder/EntitiesSeeders/Data/Authors.txt");
            foreach (string line in fileLines.Skip(1))
            {
                var item = GetItemFromLine(line);
                authors.Add(item);
            }

            builder.Entity<Author>().HasData(authors);
        }

        private static Author GetItemFromLine(string line)
        {
            string[] item = line.Split('|');
            int id = Convert.ToInt32(item[0]);
            string name = item[1];
            string description = item[2];
            return new Author() { Id = id, Name = name, Description = description };
        }
    }
}
