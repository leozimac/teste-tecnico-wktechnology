using Categories.API.Domain.Repository;
using Categories.API.Domain.Utils;
using MediatR;

namespace Categories.API.Application.Queries.GetMenu
{
    public class GetCategoryMenuQuery : IRequestHandler<GetCategoryMenuRequest, GetCategoryMenuResponse>
    {
        readonly GetCategoryMenuResponse response = new();
        readonly ICategoryRepository _repository;

        public GetCategoryMenuQuery(ICategoryRepository categoryRepository)
        {
            _repository = categoryRepository;
        }

        public async Task<GetCategoryMenuResponse> Handle(GetCategoryMenuRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var categoriesMenu = await _repository.GetCategoryForMenusAsync();

                response.Categories = categoriesMenu;
                response.StatusCode = System.Net.HttpStatusCode.OK;
            }
            catch(Exception ex) 
            {
                response.Messages.Add(ex.GetAllMessages());
                response.StatusCode = System.Net.HttpStatusCode.InternalServerError;
            }

            return response;
        }
    }
}
