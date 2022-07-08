using AutoMapper;
using OlexShop.Core.Domain.DTOs;
using OlexShop.Core.Domain.Entities;

namespace OlexShop.Core.ApplicationService.Config
{
    public class NewsCategoryProfile : Profile
    {
        public NewsCategoryProfile()
        {
            CreateMap<NewsCategory, NewsCategoryDTO>();
            CreateMap<NewsCategoryDTO, NewsCategory>();
        }
    }
}
