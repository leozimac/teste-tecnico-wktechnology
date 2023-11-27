using Categories.API.Domain.Entities;
using MediatR;

namespace Categories.API
{
    public class AddCategoryRequest : IRequest<AddCategoryResponse>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public static Category MaptToEntitie(AddCategoryRequest request)
        {
            return new Category(request.Name, request.Description);
        }
    }
}