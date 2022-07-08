using OlexShop.Core.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace OlexShop.Core.Contracts.Facade
{
    public interface IProductsCommentFacade
    {
        public IEnumerable<ProductsCommentDTO> GetComments();
        public void AddComment(ProductsCommentDTO comment);
        public void DeleteComment(int id);
    }
}
