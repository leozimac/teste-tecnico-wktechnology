using WebApp.Models;

namespace WebApp.DTOs.Category
{
    public class GetCategoriesResponse : ResponseBase
    {
        public List<CategoryViewModel> Categories { get; set; }
    }
}
