using MediatR;
using Products.API.Domain.Entities;

namespace Products.API.Application.Commands.AddProduct
{
    public class AddProductRequest : IRequest<AddProductResponse>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int IdCategory { get; set; }

        public AddProductRequest(string name, string description, double price, int idCategory)
        {
            Name = name;
            Description = description;
            Price = price;
            IdCategory = idCategory;
        }

        public static Product MapRequestToEntity(AddProductRequest addProductRequest)
        {
            return new Product(
                addProductRequest.Name,
                addProductRequest.Description,
                addProductRequest.Price,
                addProductRequest.IdCategory);
        }
    }
}
