using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class CreateProductViewModel
    {
        [Required]
        [MaxLength(80, ErrorMessage = "Name should have less than 80 characters.")]
        public string Name { get; set; }
        public string Description { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int IdCategory { get; set; }
        public List<SelectListItem>? Categories { get; set; }
    }
}
