using OlexShop.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OlexShop.Core.Contracts.Repository
{
    public interface IProductsRepository
    {
        public List<Products> GetLatestProducts();
        public Products GetProduct(int id);
        public List<Products> HomeSearch(string search);
        public List<Products> GetAll();
        public List<Products> FindByCategory(int categoryid);
        public void CreateProduct(Products products);
        public void DeleteProduct(int id);
        public void Edit(Products products);
        
    }
}
