using MediatR;
using Products.API.Domain.Entities;

namespace Products.API.Application.Commands.UpdateProduct
{
    public class UpdateProductRequest : IRequest<UpdateProductResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int IdCategory { get; set; }
    }
}
