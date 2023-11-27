using Products.API.Domain.DTOs;

namespace Products.API.Application.Queries.GetAll
{
    public class GetAllProductsResponse : ResponseBase
    {
        public List<ProductDto> Products { get; set; } = new List<ProductDto>();
    }
}
