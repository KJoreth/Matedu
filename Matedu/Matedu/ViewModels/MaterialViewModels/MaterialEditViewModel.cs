namespace Matedu.ViewModels.MaterialViewModels
{
    public class MaterialEditViewModel
    {
        public int MaterialId { get; set; }
        [Required]
        public string MaterialTitle { get; set; }
        [Required]
        [MaxLength(255)]
        public string MaterialLocation { get; set; }
        [Required]
        public int Author { get; set; }
        public List<SelectListItem> Authors { get; set; } = new();
        [Required]
        public int Type { get; set; }
        public List<SelectListItem> Types { get; set; } = new();
    }
}
