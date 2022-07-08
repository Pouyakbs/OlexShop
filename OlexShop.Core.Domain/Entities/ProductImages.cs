using Microsoft.AspNetCore.Http;

namespace OlexShop.Core.Domain.Entities
{
    public class ProductImages
    {
        public int ImageId { get; set; }
        public string ProductImage { get; set; }
        public IFormFile Images { get; set; }
        public Products Products { get; set; }
        public int ProductId { get; set; }
    }
}
