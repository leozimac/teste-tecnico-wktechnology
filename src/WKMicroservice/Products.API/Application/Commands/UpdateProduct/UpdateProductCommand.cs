using MediatR;
using Products.API.Domain.Repository;
using Products.API.Domain.Utils;

namespace Products.API.Application.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequestHandler<UpdateProductRequest, UpdateProductResponse>
    {
        readonly UpdateProductResponse response = new();
        readonly IProductRepository _repository;

        public UpdateProductCommand(IProductRepository productRepository)
        {
            _repository = productRepository;
        }

        public async Task<UpdateProductResponse> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var product = await _repository.GetByIdAsync(request.Id);

                if (product == null)
                {
                    response.Messages.Add("Product not found.");
                    response.StatusCode = System.Net.HttpStatusCode.BadRequest;

                    return response;
                }

                product.UpdateProduct(
                    request.Name,
                    request.Description,
                    request.Price,
                    request.IdCategory
                    );
                await _repository.UpdateAsync(product);

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
