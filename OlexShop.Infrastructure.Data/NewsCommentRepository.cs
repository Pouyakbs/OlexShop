using OlexShop.Core.Contracts.Repository;
using OlexShop.Core.Domain.Entities;
using OlexShop.Infrastructure.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlexShop.Infrastructure.Data
{
    public class NewsCommentRepository : INewsCommentRepository
    {
        private readonly DemoContext context;
        public NewsCommentRepository(DemoContext context)
        {
            this.context = context;
        }
        public List<NewsComment> GetComments()
        {
            return context.NewsComment.ToList();
        }
        public void AddComment(NewsComment comment)
        {
            context.NewsComment.Add(comment);
            context.SaveChanges();
        }
        public void DeleteComment(int id)
        {
            context.NewsComment.Remove(new NewsComment() { CommentId = id });
            context.SaveChanges();
        }
        

    }
}
