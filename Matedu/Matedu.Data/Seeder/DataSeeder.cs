namespace Matedu.Data.Seeder
{
    public static class DataSeeder
    {
        public static void SeedDB(this ModelBuilder builder)
        {
            builder.SeedTypes();
            builder.SeedAuthors();
            builder.SeedMaterials();
            builder.SeedRevies();
        }
    }
}
