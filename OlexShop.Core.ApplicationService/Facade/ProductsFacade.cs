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
    public class ProductsFacade : IProductsFacade
    {
        IProductsRepository ProductsRepository;
        private readonly IMapper mapper;
        public ProductsFacade(IProductsRepository ProductsRepository, IMapper mapper)
        {
            this.ProductsRepository = ProductsRepository;
            this.mapper = mapper;
        }
        public IEnumerable<ProductsDTO> GetLatestProducts()
        {
            IEnumerable<Products> products = ProductsRepository.GetLatestProducts();
            IEnumerable<ProductsDTO> productsDTOs = mapper.Map<IEnumerable<Products>, IEnumerable<ProductsDTO>>(products);
            return productsDTOs;
        }
        public IEnumerable<ProductsDTO> HomeSearch(string search)
        {
            IEnumerable<Products> products = ProductsRepository.HomeSearch(search);
            IEnumerable<ProductsDTO> productsDTOs = mapper.Map<IEnumerable<Products>, IEnumerable<ProductsDTO>>(products);
            return productsDTOs;
        }
        public IEnumerable<ProductsDTO> FindByCategory(int categoryid)
        {
            IEnumerable<Products> products = ProductsRepository.FindByCategory(categoryid);
            IEnumerable<ProductsDTO> productsDTOs = mapper.Map<IEnumerable<Products>, IEnumerable<ProductsDTO>>(products);
            return productsDTOs;
        }
        public IEnumerable<ProductsDTO> GetAll()
        {
            IEnumerable<Products> products = ProductsRepository.GetAll();
            IEnumerable<ProductsDTO> productsDTOs = mapper.Map<IEnumerable<Products>, IEnumerable<ProductsDTO>>(products);
            return productsDTOs;
        }
        public Products GetProduct(int id)
        {
            Products products = ProductsRepository.GetProduct(id);
            //ProductsDTO productsDTO = mapper.Map<Products, ProductsDTO>(products);
            return products;
        }
        public void CreateProduct(ProductsDTO products)
        {
            Products createProduct = mapper.Map<ProductsDTO, Products>(products);
            ProductsRepository.CreateProduct(createProduct);
        }
        public void Edit(Products products)
        {
            ProductsRepository.Edit(products);
        }
        public void DeleteProduct(int id)
        {
            ProductsRepository.DeleteProduct(id);
        }
    }
}
