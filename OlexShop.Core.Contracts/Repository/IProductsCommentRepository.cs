using OlexShop.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OlexShop.Core.Contracts.Repository
{
    public interface IProductsCommentRepository
    {
        public List<ProductsComment> GetComments();
        public void AddComment(ProductsComment comment);
        public void DeleteComment(int id);
    }
}
