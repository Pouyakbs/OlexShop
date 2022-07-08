using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace OlexShop.Core.Domain.Entities
{
    public class News
    {
        public News()
        {
            PubDate = DateTime.Now;
        }
        public int NewsId { get; set; }
        public string NewsTitle { get; set; }
        public string NewsSummary { get; set; }
        public string NewsText { get; set; }
        public string NewsImages { get; set; }
        public DateTime PubDate { get; set; }
        public IFormFile Images { get; set; }
        public List<NewsComment> Comments { get; set; }
        public NewsCategory Category { get; set; }
        public int CategoryId { get; set; }
    }
}
