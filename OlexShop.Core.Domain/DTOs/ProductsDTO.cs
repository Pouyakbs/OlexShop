using OlexShop.Core.Domain.Entities;
using System;
using System.Collections.Generic;

namespace OlexShop.Core.Domain.DTOs
{
    public class ProductsDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public DateTime PubDate { get; set; }
        public string Options { get; set; }
        public string Description { get; set; }
        public int ImageId { get; set; }
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
        public Products Products { get; set; }
        public List<ProductImagesDTO> ProductImages { get; set; }
    }
}
