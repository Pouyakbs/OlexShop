using System;

namespace OlexShop.Core.Domain.Entities
{
    public class NewsComment
    {
        public int CommentId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string CommentText { get; set; }
        public DateTime PubTime { get; set; }
        public News News { get; set; }
        public int NewsId { get; set; }
    }
}
