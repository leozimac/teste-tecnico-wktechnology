using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(80, ErrorMessage = "Name should be less than 80 characters.")]
        public string Name { get; set; }

        [MaxLength(255, ErrorMessage = "Description should have less than 255 characters.")]
        public string Description { get; set; }

        [Required]
        public double Price { get; set; }
        public string Category { get; set; }
    }
}
