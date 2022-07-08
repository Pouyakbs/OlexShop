using OlexShop.Core.Domain.DTOs;
using OlexShop.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlexShop.Models
{
    public class NewsViewModel
    {
        public IEnumerable<UserAuthentication> UserAuthentications { get; set; }
        public UserAuthenticationDTO User { get; set; }
        public IEnumerable<NewsDTO> News { get; set; }
        public NewsDTO NewsDTO { get; set; }
        public IEnumerable<NewsCategoryDTO> Categories { get; set; }
        public IEnumerable<ProductsDTO> latestProducts { get; set; }
        public IEnumerable<ProductsDTO> Products { get; set; }
        public Products product { get; set; }
        public ProductsCategoryDTO ProductsCategory { get; set; }
        public IEnumerable<ProductsCategoryDTO> productsCategories { get; set; }
        public IEnumerable<ProductsCommentDTO> productsComments { get; set; }
        public IEnumerable<ProductImagesDTO> ProductImages { get; set; }
        public List<CartLine> Carts { get; set; }
        public int? TotalPrice { get; set; }
        public IEnumerable<NewsCategoryViewModel> CategoriesViewModel { get; set; }
        public IEnumerable<NewsCommentDTO> Comments { get; set; }
        public NewsCommentDTO newsComment { get; set; }
        public IEnumerable<Ads> Ads { get; set; }
    }
}
