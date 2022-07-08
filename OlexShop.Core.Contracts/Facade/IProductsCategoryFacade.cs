using OlexShop.Core.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace OlexShop.Core.Contracts.Facade
{
    public interface IProductsCategoryFacade
    {
        IEnumerable<ProductsCategoryDTO> GetAll();
        ProductsCategoryDTO Get(int id);
        void CreateCategory(ProductsCategoryDTO category);
        void DeleteCategory(int id);
    }
}
