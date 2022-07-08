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
    public class ProductsCategoryRepository : IProductsCategoryRepository
    {
        private readonly DemoContext context;
        public ProductsCategoryRepository(DemoContext context)
        {
            this.context = context;
        }
        public List<ProductsCategory> GetAll()
        {
            return context.ProductsCategory.Include(a => a.Products).ToList();
        }
        public ProductsCategory Get(int id)
        {
            return context.ProductsCategory.Include(a => a.Products).First(a => a.CategoryId == id);
        }
        public void CreateCategory(ProductsCategory productCategory)
        {
            context.ProductsCategory.Add(productCategory);
            context.SaveChanges();
        }
        public void DeleteCategory(int id)
        {
            context.ProductsCategory.Remove(new ProductsCategory() { CategoryId = id });
            context.SaveChanges();
        }
    }
}
