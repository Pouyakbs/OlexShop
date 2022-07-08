using System;
using System.Collections.Generic;
using System.Text;

namespace OlexShop.Core.Domain.Entities
{
    public class Products
    {
        public Products()
        {
            int totalPrice = Price * Quantity;
        }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string Options { get; set; }
        public string Description { get; set; }
        public DateTime PubDate { get; set; }
        public List<ProductsComment> Comments { get; set; }
        public List<CartLine> CartLines { get; set; }
        public List<ProductImages> Images { get; set; }
        public int CategoryId { get; set; }
        public ProductsCategory Category { get; set; }
    }
}
