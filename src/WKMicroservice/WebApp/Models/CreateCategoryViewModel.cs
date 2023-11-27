using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class CreateCategoryViewModel
    {
        [Required]
        [MaxLength(80, ErrorMessage = "The name should be less than 80 characters.")]
        public string Name { get; set; }

        [MaxLength(255, ErrorMessage = "The description should be less than 255 characters.")]
        public string Description { get; set; }
    }
}
