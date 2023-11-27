using MediatR;
using Products.API.Domain.Repository;
using Products.API.Domain.Utils;

namespace Products.API.Application.Queries.GetAll
{
    public class GetAllProductsQuery : IRequestHandler<GetAllProductsRequest, GetAllProductsResponse>
    {
        readonly GetAllProductsResponse response = new();
        readonly IProductRepository _repository;

        public GetAllProductsQuery(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAllProductsResponse> Handle(GetAllProductsRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var products = await _repository.GetAllAsync();

                if (products is null || !products.Any())
                {
                    response.StatusCode = System.Net.HttpStatusCode.OK;
                    response.Messages.Add("No product found.");
                    return response;
                }

                response.Products = products;
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
