using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Categories.API.Domain.Entities
{
    [Table("categories")]
    public class Category
    {
        [Key]
        [Required]
        [Column("id")]
        public int Id { get; private set; }

        [Required]
        [Column("name")]
        [MaxLength(80, ErrorMessage = "Can't create names bigger than 80 characters.")]
        public string Name { get; private set; }

        [Column("description")]
        [MaxLength(255, ErrorMessage = "The description length has to be less than 255 characters.")]
        public string Description { get; private set; }

        public Category(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public void UpdateNameAndDescription(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
