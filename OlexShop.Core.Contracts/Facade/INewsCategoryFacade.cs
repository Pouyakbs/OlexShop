using OlexShop.Core.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace OlexShop.Core.Contracts.Facade
{
    public interface INewsCategoryFacade
    {
        IEnumerable<NewsCategoryDTO> GetAll();
        NewsCategoryDTO Get(int id);
        void CreateCategory(NewsCategoryDTO category);
        void DeleteCategory(int id);
    }
}
