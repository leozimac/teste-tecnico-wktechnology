using WebApp.DTOs;
using WebApp.Models;

namespace WebApp
{
    public class GetCategoryByIdResponse : ResponseBase
    {
        public CategoryViewModel Category { get; set; }
    }
}