using Categories.API.Domain.Repository;
using Categories.API.Domain.Utils;
using MediatR;

namespace Categories.API.Application.Queries.GetById
{
    public class GetCategoryByIdQuery : IRequestHandler<GetCategoryByIdRequest, GetCategoryByIdResponse>
    {
        readonly GetCategoryByIdResponse response = new();
        readonly ICategoryRepository _repository;

        public GetCategoryByIdQuery(ICategoryRepository categoryRepository)
        {
            _repository = categoryRepository;
        }

        public async Task<GetCategoryByIdResponse> Handle(GetCategoryByIdRequest request, CancellationToken cancellationToken)
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

                response.Category = new Domain.DTOs.CategoryDto
                {
                    Id = category.Id,
                    Name = category.Name,
                    Description = category.Description
                };
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
