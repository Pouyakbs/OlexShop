using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace OlexShop.Core.Domain.DTOs
{
    public class ProductImagesDTO
    {
        public int ImageId { get; set; }
        public string ProductImage { get; set; }
        public List<IFormFile> Images { get; set; }
        public string Products { get; set; }
        public int ProductId { get; set; }
    }
}
