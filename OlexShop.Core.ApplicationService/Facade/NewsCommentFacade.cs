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
    public class NewsCommentFacade : INewsCommentFacade
    {
        INewsCommentRepository NewsCommentRepository;
        private readonly IMapper mapper;
        public NewsCommentFacade(INewsCommentRepository NewsCommentRepository, IMapper mapper)
        {
            this.NewsCommentRepository = NewsCommentRepository;
            this.mapper = mapper;
        }
        public IEnumerable<NewsCommentDTO> GetComments()
        {
            IEnumerable<NewsComment> newsComments = NewsCommentRepository.GetComments();
            IEnumerable<NewsCommentDTO> newsCommentDTOs = mapper.Map<IEnumerable<NewsComment>, IEnumerable<NewsCommentDTO>>(newsComments);
            return newsCommentDTOs;
        }
        public void AddComment(NewsCommentDTO newsComment)
        {
            NewsComment news = mapper.Map<NewsCommentDTO, NewsComment>(newsComment);
            NewsCommentRepository.AddComment(news);
        }
        public void DeleteComment(int id)
        {
            NewsCommentRepository.DeleteComment(id);
        }
    }
}
