using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Products.API.Domain.Entities
{
    [Table("products")]
    public class Product
    {
        [Key]
        [Required]
        [Column("id")]
        public int Id { get; private set; }

        [Required]
        [Column("name")]
        [MaxLength(80, ErrorMessage = "Can't create names bigger than 80 characters")]
        public string Name { get; private set; }

        [Column("description")]
        [MaxLength(255, ErrorMessage = "The description length has to be less than 255 characters.")]
        public string Description { get; private set; }

        [Required]
        [Column("price")]
        [Precision(6, 2)]
        public double Price { get; private set; }

        [Required]
        [Column("id_category")]
        [ForeignKey(nameof(Category))]
        public int IdCategory { get; private set; }

        public Category Category { get; private set; }

        public Product(string name, string description, double price, int idCategory)
        {
            Name = name;
            Description = description;
            Price = price;
            IdCategory = idCategory;
        }

        public Product(int id, string name, string description, double price, int idCategory)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            IdCategory = idCategory;
        }

        public void UpdateProduct(string name, string description, double price, int idCategoty)
        {
            Name = name;
            Description = description;
            Price = price;
            IdCategory = idCategoty;
        }
    }
}
