using AutoMapper;
using OlexShop.Core.Contracts.Facade;
using OlexShop.Core.Contracts.Repository;
using OlexShop.Core.Domain.DTOs;
using OlexShop.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OlexShop.Core.ApplicationService.Facade
{
    public class NewsCategoryFacade : INewsCategoryFacade
    {
        INewsCategoryRepository NewsCategoryRepository;
        private readonly IMapper mapper;
        public NewsCategoryFacade(INewsCategoryRepository NewsCategoryRepository , IMapper mapper)
        {
            this.NewsCategoryRepository = NewsCategoryRepository;
            this.mapper = mapper;
        }
        public IEnumerable<NewsCategoryDTO> GetAll()
        {
            IEnumerable<NewsCategory> newsCategories = NewsCategoryRepository.GetAll();
            IEnumerable<NewsCategoryDTO> newsCategoryDTOs = mapper.Map<IEnumerable<NewsCategory>, IEnumerable<NewsCategoryDTO>>(newsCategories);
            return newsCategoryDTOs;
        }
        public NewsCategoryDTO Get(int id)
        {
            NewsCategory newsCategory = NewsCategoryRepository.Get(id);
            NewsCategoryDTO newsCategoryDTO = mapper.Map<NewsCategory, NewsCategoryDTO>(newsCategory);
            return newsCategoryDTO;
        }
        public void CreateCategory(NewsCategoryDTO category)
        {
            NewsCategory newsCategory = mapper.Map<NewsCategoryDTO, NewsCategory>(category);
            NewsCategoryRepository.CreateCategory(newsCategory);
        }
        public void DeleteCategory(int id)
        {
            NewsCategoryRepository.DeleteCategory(id);
        }
    }
}
