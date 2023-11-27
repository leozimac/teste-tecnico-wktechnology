using MediatR;
using Products.API.Domain.Repository;
using Products.API.Domain.Utils;

namespace Products.API.Application.Commands.DeleteProduct
{
    public class DeleteProductCommand : IRequestHandler<DeleteProductRequest, DeleteProductResponse>
    {
        readonly DeleteProductResponse response = new();
        readonly IProductRepository _repository;

        public DeleteProductCommand(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<DeleteProductResponse> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var product = await _repository.GetByIdAsync(request.id);

                if(product == null)
                {
                    response.Messages.Add("Product not found.");
                    response.StatusCode = System.Net.HttpStatusCode.BadRequest;

                    return response;
                }

                await _repository.DeleteAsync(product);
                response.StatusCode = System.Net.HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                response.Messages.Add(ex.GetAllMessages());
                response.StatusCode = System.Net.HttpStatusCode.InternalServerError;
            }

            return response;
        }
    }
}
