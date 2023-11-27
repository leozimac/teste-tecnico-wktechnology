using MediatR;

namespace Categories.API.Application.Queries.GetById
{
    public class GetCategoryByIdQuery : IRequestHandler<GetCategoryByIdRequest, GetCategoryByIdResponse>
    {
        public Task<GetCategoryByIdResponse> Handle(GetCategoryByIdRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
