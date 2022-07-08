using AutoMapper;
using OlexShop.Core.Domain.DTOs;
using OlexShop.Core.Domain.Entities;

namespace OlexShop.Core.ApplicationService.Config
{
    public class ProductsCommentProfile : Profile
    {
        public ProductsCommentProfile()
        {
            CreateMap<ProductsComment, ProductsCommentDTO>();
            CreateMap<ProductsCommentDTO, ProductsComment>();
        }
    }
}
