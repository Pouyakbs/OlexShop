using OlexShop.Core.Domain.DTOs;
using OlexShop.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OlexShop.Core.Contracts.Facade
{
    public interface IProductsFacade
    {
        IEnumerable<ProductsDTO> GetLatestProducts();
        Products GetProduct(int id);
        IEnumerable<ProductsDTO> HomeSearch(string search);
        IEnumerable<ProductsDTO> GetAll();
        IEnumerable<ProductsDTO> FindByCategory(int categoryid);
        void CreateProduct(ProductsDTO products);
        void DeleteProduct(int id);
        void Edit(Products products);
    }
}
