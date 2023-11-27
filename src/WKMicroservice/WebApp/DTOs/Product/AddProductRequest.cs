namespace WebApp.DTOs.Product
{
    public class AddProductRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int IdCategory { get; set; }
    }
}
