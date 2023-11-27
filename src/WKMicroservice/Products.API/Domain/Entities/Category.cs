using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Products.API.Domain.Entities
{
    [Table("categories")]
    public class Category
    {
        [Required]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("name")]
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }

        public Category(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}