using System.Collections.Generic;

namespace OlexShop.Core.Domain.Entities
{
    public class ProductsCategory
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<Products> Products { get; set; }
    }
}
