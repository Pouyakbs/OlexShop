using OlexShop.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OlexShop.Core.Contracts.Repository
{
    public interface INewsCategoryRepository
    {
        List<NewsCategory> GetAll();
        NewsCategory Get(int id);
        void CreateCategory(NewsCategory category);
        void DeleteCategory(int id);
    }
}
