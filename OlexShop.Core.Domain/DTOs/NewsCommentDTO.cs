using System;

namespace OlexShop.Core.Domain.DTOs
{
    public class NewsCommentDTO
    {
        public int CommentId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string CommentText { get; set; }
        public DateTime PubTime { get; set; }
        public string NewsTitle { get; set; }
        public int NewsId { get; set; }
    }
}
