using AutoMapper;
using OlexShop.Core.Domain.DTOs;
using OlexShop.Core.Domain.Entities;

namespace OlexShop.Core.ApplicationService.Config
{
    public class UserAuthenticationProfile : Profile
    {
        public UserAuthenticationProfile()
        {
            CreateMap<UserAuthentication, UserAuthenticationDTO>();
            CreateMap<UserAuthenticationDTO, UserAuthentication>();
        }
    }
}
