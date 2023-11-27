namespace WebApp.DTOs.Category
{
    public class GetCategoriesMenuResponse : ResponseBase
    {
        public List<CategoriesMenuDto> Categories { get; set; }
    }
}
