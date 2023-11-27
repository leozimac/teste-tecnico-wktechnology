using Categories.API.Domain.DTOs;

namespace Categories.API
{
    public class GetCategoryByIdResponse : ResponseBase
    {
        public CategoryDto Category { get; set; }
    }
}