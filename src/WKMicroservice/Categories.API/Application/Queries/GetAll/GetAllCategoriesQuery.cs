using Categories.API.Domain.Repository;
using Categories.API.Domain.Utils;
using MediatR;

namespace Categories.API.Application.Queries.GetAll
{
    public class GetAllCategoriesQuery : IRequestHandler<GetAllCategoriesRequest, GetAllCategoriesResponse>
    {
        readonly GetAllCategoriesResponse response = new();
        readonly ICategoryRepository _repository;

        public GetAllCategoriesQuery(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAllCategoriesResponse> Handle(GetAllCategoriesRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var categories = await _repository.GetAllAsync();

                if(categories is null)
                {
                    response.StatusCode = System.Net.HttpStatusCode.OK;
                    response.Messages.Add("No categories found.");
                    return response;
                }

                response.Categories = categories;
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
