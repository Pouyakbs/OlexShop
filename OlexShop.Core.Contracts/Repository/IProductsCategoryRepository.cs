using OlexShop.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OlexShop.Core.Contracts.Repository
{
    public interface IProductsCategoryRepository
    {
        List<ProductsCategory> GetAll();
        ProductsCategory Get(int id);
        void CreateCategory(ProductsCategory category);
        void DeleteCategory(int id);
    }
}
