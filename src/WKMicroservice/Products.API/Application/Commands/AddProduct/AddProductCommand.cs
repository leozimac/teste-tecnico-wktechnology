using MediatR;
using Products.API.Domain.Repository;
using Products.API.Domain.Utils;

namespace Products.API.Application.Commands.AddProduct
{
    public class AddProductCommand : IRequestHandler<AddProductRequest, AddProductResponse>
    {
        AddProductResponse response = new();
        IProductRepository _repository;

        public AddProductCommand(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<AddProductResponse> Handle(AddProductRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var newProduct = AddProductRequest.MapRequestToEntity(request);
                var result = await _repository.AddAsync(newProduct);

                if(result == 0)
                {
                    response.Messages.Add("Error while adding new Product.");
                    response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    return response;
                }

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
