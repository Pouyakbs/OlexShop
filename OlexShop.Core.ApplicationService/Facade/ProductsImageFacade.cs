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
    public class ProductsImageFacade : IProductsImageFacade
    {
        IProductsImageRepository ProductsImageRepository;
        private readonly IMapper mapper;
        public ProductsImageFacade(IProductsImageRepository ProductsImageRepository, IMapper mapper)
        {
            this.ProductsImageRepository = ProductsImageRepository;
            this.mapper = mapper;
        }
        public IEnumerable<ProductImagesDTO> GetAll()
        {
            IEnumerable<ProductImages> productImages = ProductsImageRepository.GetAll();
            IEnumerable<ProductImagesDTO> productImagesDTOs = mapper.Map<IEnumerable<ProductImages>, IEnumerable<ProductImagesDTO>>(productImages);
            return productImagesDTOs;
        }
        public void AddImage(ProductImagesDTO productImages)
        {
            ProductImages product = mapper.Map<ProductImagesDTO, ProductImages>(productImages);
            ProductsImageRepository.AddImage(product);
        }
        public void DeleteImage(int id)
        {
            ProductsImageRepository.DeleteImage(id);
        }
    }
}
