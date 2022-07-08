using AutoMapper;
using OlexShop.Core.Domain.DTOs;
using OlexShop.Core.Domain.Entities;

namespace OlexShop.Core.ApplicationService.Config
{
    public class ProductsImagesProfile : Profile
    {
        public ProductsImagesProfile()
        {
            CreateMap<ProductImages, ProductImagesDTO>();
            CreateMap<ProductImagesDTO, ProductImages>();
        }
    }
}
