using MediatR;

namespace Categories.API.Application.Queries.GetMenu
{
    public class GetCategoryMenuQuery : IRequestHandler<GetCategoryMenuRequest, GetCategoryMenuResponse>
    {
        public Task<GetCategoryMenuResponse> Handle(GetCategoryMenuRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
