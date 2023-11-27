using MediatR;
using Products.API.Data.Repositories;
using Products.API.Domain.Repository;
using Products.API.Domain.Utils;

namespace Products.API.Application.Queries.GetById
{
    public class GetProductByIdQuery : IRequestHandler<GetProductByIdRequest, GetProductByIdResponse>
    {
        readonly GetProductByIdResponse response = new();
        readonly IProductRepository _repository;

        public GetProductByIdQuery(IProductRepository productRepository)
        {
            _repository = productRepository;
        }

        public async Task<GetProductByIdResponse> Handle(GetProductByIdRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var product = await _repository.GetDetailsAsync(request.id);

                if (product == null)
                {
                    response.Messages.Add("Product not found.");
                    response.StatusCode = System.Net.HttpStatusCode.NotFound;

                    return response;
                }

                response.Product = product;
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
