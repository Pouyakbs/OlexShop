using AutoMapper;
using OlexShop.Core.Domain.DTOs;
using OlexShop.Core.Domain.Entities;

namespace OlexShop.Core.ApplicationService.Config
{
    public class AdminAuthenticationProfile : Profile
    {
        public AdminAuthenticationProfile()
        {
            CreateMap<AdminAuthentication, AdminAuthenticationDTO>();
            CreateMap<AdminAuthenticationDTO, AdminAuthentication>();
        }
    }
}
