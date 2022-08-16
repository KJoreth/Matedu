namespace Matedu.Data.Seeder.EntitiesSeeders.Seeders
{
    public static class TypesSeeder
    {
        public static void SeedTypes(this ModelBuilder builder)
        {
            List<Entities.MaterialType> types = new List<Entities.MaterialType>();
            string[] fileLines = File.ReadAllLines("../Matedu.Data/Seeder/EntitiesSeeders/Data/Types.txt");
            foreach (string line in fileLines.Skip(1))
            {
                var item = GetItemFromLine(line);
                types.Add(item);
            }

            builder.Entity<Entities.MaterialType>().HasData(types);
        }

        private static Entities.MaterialType GetItemFromLine(string line)
        {
            string[] item = line.Split('|');
            int id = Convert.ToInt32(item[0]);
            string name = item[1];
            string definition = item[2];
            return new Entities.MaterialType() { Id = id, Name = name, Definition = definition };
        }
    }
}
