using AutoMapper;
using OlexShop.Core.Domain.DTOs;
using OlexShop.Core.Domain.Entities;

namespace OlexShop.Core.ApplicationService.Config
{
    public class AdsProfile : Profile
    {
        public AdsProfile()
        {
            CreateMap<Ads, AdsDTO>();
            CreateMap<AdsDTO, Ads>();
        }
    }
}
