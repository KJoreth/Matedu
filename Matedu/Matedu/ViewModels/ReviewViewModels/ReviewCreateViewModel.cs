namespace Matedu.ViewModels.ReviewViewModels
{
    public class ReviewCreateViewModel
    {
        public int MaterialId { get; set; }
        [Required]
        [Range(1, 10)]
        [Display(Name = "Points / 10")]
        public int Points { get; set; }
        [Required]
        [MaxLength(255)]
        public string Text { get; set; }
    }
}
