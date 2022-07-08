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
    public class NewsCategoryRepository : INewsCategoryRepository
    {
        private readonly DemoContext context;
        public NewsCategoryRepository(DemoContext context)
        {
            this.context = context;
        }
        public List<NewsCategory> GetAll()
        {
            return context.NewsCategory.Include(a => a.News).ToList();
        }
        public NewsCategory Get(int id)
        {
            return context.NewsCategory.Include(a => a.News).First(a => a.CategoryId == id);
        }
        public void CreateCategory(NewsCategory newsCategory)
        {
            context.NewsCategory.Add(newsCategory);
            context.SaveChanges();
        }
        public void DeleteCategory(int id)
        {
            context.NewsCategory.Remove(new NewsCategory() { CategoryId = id });
            context.SaveChanges();
        }
    }
}
