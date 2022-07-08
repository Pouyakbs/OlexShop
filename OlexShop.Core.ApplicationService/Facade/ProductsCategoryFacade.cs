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
    public class ProductsCategoryFacade : IProductsCategoryFacade
    {
        IProductsCategoryRepository ProductsCategoryRepository;
        private readonly IMapper mapper;
        public ProductsCategoryFacade(IProductsCategoryRepository ProductsCategoryRepository, IMapper mapper)
        {
            this.ProductsCategoryRepository = ProductsCategoryRepository;
            this.mapper = mapper;
        }
        public IEnumerable<ProductsCategoryDTO> GetAll()
        {
            IEnumerable<ProductsCategory> productsCategories = ProductsCategoryRepository.GetAll();
            IEnumerable<ProductsCategoryDTO> productsCategoryDTOs = mapper.Map<IEnumerable<ProductsCategory>, IEnumerable<ProductsCategoryDTO>>(productsCategories);
            return productsCategoryDTOs;
        }
        public ProductsCategoryDTO Get(int id)
        {
            ProductsCategory productsCategory = ProductsCategoryRepository.Get(id);
            ProductsCategoryDTO productsCategoryDTO = mapper.Map<ProductsCategory, ProductsCategoryDTO>(productsCategory);
            return productsCategoryDTO;
        }
        public void CreateCategory(ProductsCategoryDTO category)
        {
            ProductsCategory productsCategory = mapper.Map<ProductsCategoryDTO, ProductsCategory>(category);
            ProductsCategoryRepository.CreateCategory(productsCategory);
        }
        public void DeleteCategory(int id)
        {
            ProductsCategoryRepository.DeleteCategory(id);
        }
    }
}
