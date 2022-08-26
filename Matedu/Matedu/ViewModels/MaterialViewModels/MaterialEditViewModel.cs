namespace Matedu.ViewModels.MaterialViewModels
{
    public class MaterialEditViewModel
    {
        public int MaterialId { get; set; }
        [Required]
        [Display(Name = "Material Title")]
        public string MaterialTitle { get; set; }
        [Required]
        [MaxLength(255)]
        [Display(Name = "Material Location")]
        public string MaterialLocation { get; set; }
        [Required]
        public int Author { get; set; }
        public List<SelectListItem> Authors { get; set; } = new();
        [Required]
        public int Type { get; set; }
        public List<SelectListItem> Types { get; set; } = new();
    }
}
