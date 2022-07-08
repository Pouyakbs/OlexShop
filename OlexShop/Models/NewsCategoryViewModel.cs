using OlexShop.Core.Domain.DTOs;
using System.Collections.Generic;

namespace OlexShop.Models
{
    public class NewsCategoryViewModel
    {
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public int NewsCount { get; set; }
        public string CategoryName { get; set; }
    }
}
