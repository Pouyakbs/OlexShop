using System.Collections.Generic;

namespace OlexShop.Core.Domain.Entities
{
    public class NewsCategory
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<News> News { get; set; }
    }
}
