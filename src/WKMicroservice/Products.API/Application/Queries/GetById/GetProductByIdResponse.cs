using Products.API.Domain.DTOs;

namespace Products.API.Application.Queries.GetById
{
    public class GetProductByIdResponse : ResponseBase
    {
        public ProductDetailsDto Product { get; set; }
    }
}
