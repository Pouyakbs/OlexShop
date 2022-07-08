using Microsoft.EntityFrameworkCore;
using OlexShop.Core.Contracts.Repository;
using OlexShop.Core.Domain.Entities;
using OlexShop.Infrastructure.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OlexShop.Infrastructure.Data
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly DemoContext context;
        public ProductsRepository(DemoContext context)
        {
            this.context = context;
        }
        public List<Products> GetLatestProducts()
        {
            return context.Products.Include(a=>a.Images).OrderByDescending(a => a.PubDate).Take(8).ToList();
        }
        public Products GetProduct(int id)
        {
            return context.Products.Include(a=>a.Images).First(a=>a.ProductId == id);
        }
        public List<Products> HomeSearch(string search)
        {
            return context.Products.Where(a => a.ProductName.Contains(search) || a.Category.CategoryName.Contains(search)).ToList();
        }
        public List<Products> GetAll()
        {
            return context.Products.Include(a=>a.Images).ToList();
        }
        public List<Products> FindByCategory(int categoryid)
        {
            return context.Products.Include(a => a.Category).Where(a => a.CategoryId == categoryid).ToList();
        }
        public void CreateProduct(Products products)
        {
            context.Products.Add(products);
            context.SaveChanges();
        }
        public void DeleteProduct(int id)
        {
            context.Products.Remove(new Products() { ProductId = id });
            context.SaveChanges();
        }
        public void Edit(Products products)
        {
            context.Products.Update(products);
            context.SaveChanges();
        }
    }
}
