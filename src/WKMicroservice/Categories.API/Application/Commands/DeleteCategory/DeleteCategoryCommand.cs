using Categories.API.Domain.Repository;
using Categories.API.Domain.Utils;
using MediatR;

namespace Categories.API.Application.Commands.DeleteCategory
{
    public class DeleteCategoryCommand : IRequestHandler<DeleteCategoryRequest, DeleteCategoryResponse>
    {
        readonly DeleteCategoryResponse response = new();
        readonly ICategoryRepository _repository;

        public DeleteCategoryCommand(ICategoryRepository categoryRepository)
        {
            _repository =  categoryRepository;
        }

        public async Task<DeleteCategoryResponse> Handle(DeleteCategoryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var category = await _repository.GetByIdAsync(request.id);

                if (category is null)
                {
                    response.Messages.Add("Category not found.");
                    response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    return response;
                }

                await _repository.DeleteAsync(category);
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
