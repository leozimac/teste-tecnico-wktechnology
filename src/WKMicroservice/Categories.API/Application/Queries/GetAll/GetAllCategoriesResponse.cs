using Categories.API.Domain.DTOs;

namespace Categories.API.Application.Queries.GetAll
{
    public class GetAllCategoriesResponse : ResponseBase
    {
        public List<CategoryDto> Categories { get; set; } = new List<CategoryDto>();
    }
}
