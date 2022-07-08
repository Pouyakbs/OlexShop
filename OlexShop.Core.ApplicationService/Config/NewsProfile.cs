using AutoMapper;
using OlexShop.Core.Domain.DTOs;
using OlexShop.Core.Domain.Entities;

namespace OlexShop.Core.ApplicationService.Config
{
    public class NewsProfile : Profile
    {
        public NewsProfile()
        {
            CreateMap<News, NewsDTO>();
            CreateMap<NewsDTO, News>();
        }
    }
}
