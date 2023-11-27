using WebApp.Models;

namespace WebApp.DTOs.Product
{
    public class GetProductsResponse : ResponseBase
    {
        public List<ProductViewModel> Products { get; set; }
    }
}
