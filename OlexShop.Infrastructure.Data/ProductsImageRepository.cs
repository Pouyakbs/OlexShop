using OlexShop.Core.Contracts.Repository;
using OlexShop.Core.Domain.Entities;
using OlexShop.Infrastructure.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OlexShop.Infrastructure.Data
{
    public class ProductsImageRepository : IProductsImageRepository
    {
        private readonly DemoContext context;
        public ProductsImageRepository(DemoContext context)
        {
            this.context = context;
        }
        public List<ProductImages> GetAll()
        {
            return context.ProductImages.ToList();
        }
        public void AddImage(ProductImages productImages)
        {
            context.ProductImages.Add(productImages);
            context.SaveChanges();
        }
        public void DeleteImage(int id)
        {
            context.ProductImages.Remove(new ProductImages() { ImageId = id });
            context.SaveChanges();
        }
    }
}
