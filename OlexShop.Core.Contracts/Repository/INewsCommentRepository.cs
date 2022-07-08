using OlexShop.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OlexShop.Core.Contracts.Repository
{
    public interface INewsCommentRepository
    {
        public List<NewsComment> GetComments();
        public void AddComment(NewsComment comment);
        public void DeleteComment(int id);
    }
}
