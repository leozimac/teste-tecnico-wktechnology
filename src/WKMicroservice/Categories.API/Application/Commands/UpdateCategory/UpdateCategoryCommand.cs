using Categories.API.Domain.Repository;
using Categories.API.Domain.Utils;
using MediatR;

namespace Categories.API.Application.Commands.UpdateCategory
{
    public class UpdateCategoryCommand : IRequestHandler<UpdateCategoryRequest, UpdateCategoryResponse>
    {
        readonly UpdateCategoryResponse response = new();
        readonly ICategoryRepository _repository;

        public UpdateCategoryCommand(ICategoryRepository categoryRepository)
        {
            _repository = categoryRepository;
        }

        public async Task<UpdateCategoryResponse> Handle(UpdateCategoryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var category = await _repository.GetByIdAsync(request.Id);

                if (category is null)
                {
                    response.Messages.Add("Category not found.");
                    response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    
                    return response;
                }

                category.UpdateNameAndDescription(request.Name, request.Description);
                await _repository.UpdateAsync(category);

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
