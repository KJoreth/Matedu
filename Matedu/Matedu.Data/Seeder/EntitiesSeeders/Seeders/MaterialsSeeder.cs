namespace Matedu.Data.Seeder.EntitiesSeeders.Seeders
{
    public static class MaterialsSeeder
    {
        public static void SeedMaterials(this ModelBuilder builder)
        {
            List<Material> materials = new List<Material>();
            string[] fileLines = File.ReadAllLines("../Matedu.Data/Seeder/EntitiesSeeders/Data/Materials.txt");
            foreach (string line in fileLines.Skip(1))
            {
                var item = GetItemFromLine(line);
                materials.Add(item);
            }

            builder.Entity<Material>().HasData(materials);
        }

        private static Material GetItemFromLine(string line)
        {
            string[] item = line.Split('|');
            int id = Convert.ToInt32(item[0]);
            string title = item[1];
            string location = item[2];
            DateTime dateTime = DateTime.Parse(item[3]);
            int authorId = Convert.ToInt32(item[4]);
            int typeId = Convert.ToInt32(item[5]);

            return new Material()
            {
                Id = id,
                Title = title,
                Location = location,
                PublishDate = dateTime,
                AuthorId = authorId,
                TypeId = typeId
            };
        }
    }
}
