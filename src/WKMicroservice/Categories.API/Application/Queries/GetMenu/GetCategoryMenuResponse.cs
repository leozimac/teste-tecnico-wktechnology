using Categories.API.Domain.DTOs;

namespace Categories.API
{
    public class GetCategoryMenuResponse : ResponseBase
    {
        public List<CategoryMenuDto> Categories { get; set; }
    }
}