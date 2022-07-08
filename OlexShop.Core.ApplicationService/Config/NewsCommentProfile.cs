using AutoMapper;
using OlexShop.Core.Domain.DTOs;
using OlexShop.Core.Domain.Entities;

namespace OlexShop.Core.ApplicationService.Config
{
    public class NewsCommentProfile : Profile
    {
        public NewsCommentProfile()
        {
            CreateMap<NewsComment, NewsCommentDTO>();
            CreateMap<NewsCommentDTO, NewsComment>();
        }
    }
}
