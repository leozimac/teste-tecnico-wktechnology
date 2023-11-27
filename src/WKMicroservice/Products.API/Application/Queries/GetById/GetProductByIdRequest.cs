using MediatR;

namespace Products.API.Application.Queries.GetById
{
    public class GetProductByIdRequest : IRequest<GetProductByIdResponse>
    {
        public int id { get; set; }
    }
}
