using OlexShop.Core.Domain.DTOs;
using OlexShop.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OlexShop.Core.Contracts.Facade
{
    public interface INewsFacade
    {
        IEnumerable<NewsDTO> GetHottestNews();
        IEnumerable<NewsDTO> HomeSearch(string search);
        NewsDTO GetNews(int id);
        IEnumerable<NewsDTO> GetAll();
        void CreateNews(NewsDTO news);
        void Edit(NewsDTO news);
        void DeleteNews(int id);
        dynamic NewsDetails(int id);
        IEnumerable<NewsDTO> FindByCategory(int categoryid);
    }
}
