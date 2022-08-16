namespace Matedu.Data.Entities
{
    public class MaterialType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Definition { get; set; }
        public List<Material> Materials { get; set; } = new List<Material>();
    }
}
