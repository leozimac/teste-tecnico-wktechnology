using MediatR;

namespace Products.API.Application.Commands.DeleteProduct
{
    public class DeleteProductRequest : IRequest<DeleteProductResponse>
    {
        public int id { get; set; }
    }
}
