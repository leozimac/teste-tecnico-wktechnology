using WebApp.DTOs;
using WebApp.DTOs.Product;

namespace WebApp
{
    public class GetProductByIdResponse : ResponseBase
    {
        public ProductDto Product { get; set; }
    }
}