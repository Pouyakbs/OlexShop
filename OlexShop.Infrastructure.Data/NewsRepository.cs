using Microsoft.EntityFrameworkCore;
using OlexShop.Core.Contracts.Repository;
using OlexShop.Core.Domain.Entities;
using OlexShop.Infrastructure.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OlexShop.Infrastructure.Data
{
    public class NewsRepository : INewsRepository
    {
        private readonly DemoContext context;
        public NewsRepository(DemoContext context)
        {
            this.context = context;
        }
        public List<News> GetHottestNews()
        {
            return context.News.OrderByDescending(a => a.PubDate).Take(3).ToList();
        }
        public List<News> HomeSearch(string search)
        {
            return context.News.Where(a => a.NewsTitle.Contains(search) || a.NewsSummary.Contains(search)).ToList();
        }
        public News GetNews(int id)
        {
            return context.News.Find(id);
        }
        public List<News> GetAll()
        {
            return context.News.ToList();
        }
        public void CreateNews(News news)
        {
            context.News.Add(news);
            context.SaveChanges();
        }
        public void Edit(News news)
        {
            context.News.Update(news);
            context.SaveChanges();
        }
        public void DeleteNews(int id)
        {
            context.News.Remove(new News() { NewsId = id });
            context.SaveChanges();
        }
        public dynamic NewsDetails(int id)
        {
            return context.News.Find(id);
        }
        public List<News> FindByCategory(int categoryid)
        {
            return context.News.Include(a=>a.Category).Where(a => a.CategoryId == categoryid).ToList();
        }
    }
}
