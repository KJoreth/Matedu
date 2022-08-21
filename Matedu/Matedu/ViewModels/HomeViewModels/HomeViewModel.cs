namespace Matedu.ViewModels.HomeViewModels
{
    public class HomeViewModel
    {
        public int MaterialCounter { get; set; }
        public int AuthorCounter { get; set; }
        public int TypeCounter { get; set; }
        public List<MaterialDetailedDTO> TopMaterials { get; set; } = new List<MaterialDetailedDTO>();
    }
}
