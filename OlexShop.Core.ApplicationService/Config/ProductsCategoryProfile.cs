using AutoMapper;
using OlexShop.Core.Domain.DTOs;
using OlexShop.Core.Domain.Entities;

namespace OlexShop.Core.ApplicationService.Config
{
    public class ProductsCategoryProfile : Profile
    {
        public ProductsCategoryProfile()
        {
            CreateMap<ProductsCategory, ProductsCategoryDTO>();
            CreateMap<ProductsCategoryDTO, ProductsCategory>();
        }
    }
}
