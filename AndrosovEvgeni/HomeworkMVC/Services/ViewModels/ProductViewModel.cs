using System.ComponentModel.DataAnnotations;

namespace Services.ViewModels
{
    public class ProductViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Name = "Название")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Категория")]
        [Required]
        public string Category { get; set; }
    }
}
