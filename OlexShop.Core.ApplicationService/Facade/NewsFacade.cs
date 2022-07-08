using AutoMapper;
using OlexShop.Core.Contracts.Facade;
using OlexShop.Core.Contracts.Repository;
using OlexShop.Core.Domain.DTOs;
using OlexShop.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OlexShop.Core.ApplicationService.Facade
{
    public class NewsFacade : INewsFacade
    {
        INewsRepository NewsRepository;
        private readonly IMapper mapper;
        public NewsFacade(INewsRepository NewsRepository , IMapper mapper)
        {
            this.NewsRepository = NewsRepository;
            this.mapper = mapper;
        }
        public IEnumerable<NewsDTO> GetHottestNews()
        {
            IEnumerable<News> news = NewsRepository.GetHottestNews();
            IEnumerable<NewsDTO> newsDTOs = mapper.Map<IEnumerable<News>, IEnumerable<NewsDTO>>(news);
            return newsDTOs;
        }
        public IEnumerable<NewsDTO> HomeSearch(string search)
        {
            IEnumerable<News> news = NewsRepository.HomeSearch(search);
            IEnumerable<NewsDTO> newsDTOs = mapper.Map<IEnumerable<News>, IEnumerable<NewsDTO>>(news);
            return newsDTOs;
        }
        public NewsDTO GetNews(int id)
        {
            News news = NewsRepository.GetNews(id);
            NewsDTO newsDTO = mapper.Map<News, NewsDTO>(news);
            return newsDTO;
        }
        public IEnumerable<NewsDTO> GetAll()
        {
            IEnumerable<News> news = NewsRepository.GetAll();
            IEnumerable<NewsDTO> newsDTOs = mapper.Map<IEnumerable<News>, IEnumerable<NewsDTO>>(news);
            return newsDTOs;
        }
        public void CreateNews(NewsDTO news)
        {
            News createNews = mapper.Map<NewsDTO, News>(news);
            NewsRepository.CreateNews(createNews);
        }
        public void Edit(NewsDTO news)
        {
            News Edit = mapper.Map<NewsDTO, News>(news);
            NewsRepository.Edit(Edit);
        }
        public void DeleteNews(int id)
        {
            NewsRepository.DeleteNews(id);
        }
        public dynamic NewsDetails(int id)
        {
            return NewsRepository.NewsDetails(id);
        }
        public IEnumerable<NewsDTO> FindByCategory(int categoryId)
        {
            IEnumerable<News> news = NewsRepository.FindByCategory(categoryId);
            IEnumerable<NewsDTO> newsDTOs = mapper.Map<IEnumerable<News>, IEnumerable<NewsDTO>>(news);
            return newsDTOs;
        }
    }
}
