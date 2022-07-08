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
    public class ProductsCommentFacade : IProductsCommentFacade
    {
        IProductsCommentRepository ProductsCommentRepository;
        private readonly IMapper mapper;
        public ProductsCommentFacade(IProductsCommentRepository ProductsCommentRepository, IMapper mapper)
        {
            this.ProductsCommentRepository = ProductsCommentRepository;
            this.mapper = mapper;
        }
        public IEnumerable<ProductsCommentDTO> GetComments()
        {
            IEnumerable<ProductsComment> productsComments = ProductsCommentRepository.GetComments();
            IEnumerable<ProductsCommentDTO> productsCommentDTOs = mapper.Map<IEnumerable<ProductsComment>, IEnumerable<ProductsCommentDTO>>(productsComments);
            return productsCommentDTOs;
        }
        public void AddComment(ProductsCommentDTO comment)
        {
            ProductsComment productsComment = mapper.Map<ProductsCommentDTO, ProductsComment>(comment);
            ProductsCommentRepository.AddComment(productsComment);
        }
        public void DeleteComment(int id)
        {
            ProductsCommentRepository.DeleteComment(id);
        }
    }
}
