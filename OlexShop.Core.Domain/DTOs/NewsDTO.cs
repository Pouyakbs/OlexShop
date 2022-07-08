using Microsoft.AspNetCore.Http;
using OlexShop.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OlexShop.Core.Domain.DTOs
{
    public class NewsDTO
    {
        public int NewsId { get; set; }
        public string NewsTitle { get; set; }
        public string NewsSummary { get; set; }
        public string NewsText { get; set; }
        public DateTime PubDate { get; set; }
        public string NewsImages { get; set; }
        public List<IFormFile> Images { get; set; }
        public NewsCategory NewsCategory { get; set; }
        public int CategoryId { get; set; }
    }
}
