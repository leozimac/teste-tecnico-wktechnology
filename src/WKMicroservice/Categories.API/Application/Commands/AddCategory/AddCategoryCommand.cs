using Categories.API.Domain.Repository;
using Categories.API.Domain.Utils;
using MediatR;

namespace Categories.API.Application.Commands.AddCategory
{
    public class AddCategoryCommand : IRequestHandler<AddCategoryRequest, AddCategoryResponse>
    {
        readonly AddCategoryResponse response = new();
        readonly ICategoryRepository _repository;

        public AddCategoryCommand(ICategoryRepository categoryRepository)
        {
            _repository = categoryRepository;
        }

        public async Task<AddCategoryResponse> Handle(AddCategoryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var newCategory = AddCategoryRequest.MaptToEntitie(request);
                var result = await _repository.AddAsync(newCategory);

                if (result == 0)
                {
                    response.Messages.Add("Error while adding new category.");
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
