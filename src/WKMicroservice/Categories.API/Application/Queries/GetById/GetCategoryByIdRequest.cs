using MediatR;

namespace Categories.API
{
    public class GetCategoryByIdRequest : IRequest<GetCategoryByIdResponse>
    {
        public int id { get; set; }
    }
}