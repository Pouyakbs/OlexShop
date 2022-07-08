using OlexShop.Core.Contracts.Repository;
using OlexShop.Core.Domain.Entities;
using OlexShop.Infrastructure.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OlexShop.Infrastructure.Data
{
    public class ProductsCommentRepository : IProductsCommentRepository
    {
        private readonly DemoContext context;
        public ProductsCommentRepository(DemoContext context)
        {
            this.context = context;
        }
        public List<ProductsComment> GetComments()
        {
            return context.ProductsComment.ToList();
        }
        public void AddComment(ProductsComment comment)
        {
            context.ProductsComment.Add(comment);
            context.SaveChanges();
        }
        public void DeleteComment(int id)
        {
            context.ProductsComment.Remove(new ProductsComment() { CommentId = id });
            context.SaveChanges();
        }
    }
}
