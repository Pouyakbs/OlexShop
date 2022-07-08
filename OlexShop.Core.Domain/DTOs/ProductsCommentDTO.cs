using System;

namespace OlexShop.Core.Domain.DTOs
{
    public class ProductsCommentDTO
    {
        public int CommentId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string CommentText { get; set; }
        public DateTime PubTime { get; set; }
        public string ProductName { get; set; }
        public int ProductId { get; set; }
    }
}
