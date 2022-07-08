using OlexShop.Core.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlexShop.Areas.Admin.Models
{
    public class AdminViewModel
    {
        public IEnumerable<UserAuthenticationDTO> Users { get; set; }
        public IEnumerable<NewsCommentDTO> Comments { get; set; }
        public IEnumerable<NewsDTO> news { get; set; }
        public IEnumerable<NewsCategoryDTO> newsCategories { get; set; }
        public IEnumerable<ProductsCategoryDTO> productsCategories { get; set; }
        public IEnumerable<ProductsCommentDTO> ProductsComments { get; set; }
        public IEnumerable<ProductsDTO> Products { get; set; }
    }
}
