using System.Collections.Generic;

namespace OlexShop.Core.Domain.DTOs
{
    public class NewsCategoryDTO
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Title { get; set; }
        public List<NewsDTO> News { get; set; }
        public int NewsCount { get; set; }
    }
}
