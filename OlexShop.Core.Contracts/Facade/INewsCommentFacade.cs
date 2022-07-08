using OlexShop.Core.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace OlexShop.Core.Contracts.Facade
{
    public interface INewsCommentFacade
    {
        public IEnumerable<NewsCommentDTO> GetComments();
        public void AddComment(NewsCommentDTO comment);
        public void DeleteComment(int id);
    }
}
