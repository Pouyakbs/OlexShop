using OlexShop.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OlexShop.Core.Contracts.Repository
{
    public interface INewsRepository
    {
        List<News> GetHottestNews();
        List<News> HomeSearch(string search);
        News GetNews(int id);
        List<News> GetAll();
        void CreateNews(News news);
        void Edit(News news);
        void DeleteNews(int id);
        dynamic NewsDetails(int id);
        List<News> FindByCategory(int categoryId);
    }
}
