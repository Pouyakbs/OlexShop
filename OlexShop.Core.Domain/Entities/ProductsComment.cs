using System;

namespace OlexShop.Core.Domain.Entities
{
    public class ProductsComment
    {
        public int CommentId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string CommentText { get; set; }
        public DateTime PubTime { get; set; }
        public Products Products { get; set; }
        public int ProductId { get; set; }
    }
}
