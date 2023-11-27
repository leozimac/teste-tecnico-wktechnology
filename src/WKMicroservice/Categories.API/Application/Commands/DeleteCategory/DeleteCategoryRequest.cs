using MediatR;

namespace Categories.API
{
    public class DeleteCategoryRequest : IRequest<DeleteCategoryResponse>
    {
        public int id { get; set; }
    }
}