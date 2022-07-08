using OlexShop.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OlexShop.Core.Contracts.Repository
{
    public interface IProductsImageRepository
    {
        public List<ProductImages> GetAll();
        public void AddImage(ProductImages productImages);
        public void DeleteImage(int id);
    }
}
