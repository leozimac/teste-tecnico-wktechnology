using MediatR;

namespace Categories.API
{
    public class GetCategoryMenuRequest : IRequest<GetCategoryMenuResponse>
    {
        public GetCategoryMenuRequest()
        {
        }
    }
}