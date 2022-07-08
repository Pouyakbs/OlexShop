using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OlexShop.Core.Contracts.Facade;
using OlexShop.Core.Domain.DTOs;
using OlexShop.Core.Domain.Entities;
using OlexShop.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OlexShop.Controllers
{
    public class HomeController : Controller
    {
        INewsFacade newsFacade;
        INewsCategoryFacade newsCategoryFacade;
        INewsCommentFacade newsCommentFacade;
        IProductsFacade productsFacade;
        IProductsCategoryFacade productsCategoryFacade;
        IProductsCommentFacade productsCommentFacade;
        IProductsImageFacade productsImageFacade;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, INewsFacade newsFacade , INewsCategoryFacade newsCategoryFacade , INewsCommentFacade newsCommentFacade , IProductsFacade productsFacade
            , IProductsCategoryFacade productsCategoryFacade, IProductsCommentFacade productsCommentFacade, IProductsImageFacade productsImageFacade)
        {
            _logger = logger;
            this.newsFacade = newsFacade;
            this.newsCategoryFacade = newsCategoryFacade;
            this.newsCommentFacade = newsCommentFacade;
            this.productsFacade = productsFacade;
            this.productsCategoryFacade = productsCategoryFacade;
            this.productsCommentFacade = productsCommentFacade;
            this.productsImageFacade = productsImageFacade;
        }

        public IActionResult Index(string search , int id)
        {
            IEnumerable<ProductsDTO> products = productsFacade.GetAll();
            if (!string.IsNullOrEmpty(search))
            {
                products = productsFacade.HomeSearch(search);
            }
            else
            {
                products = productsFacade.GetAll();
            }
            IEnumerable<NewsDTO> news = newsFacade.GetHottestNews();
            IEnumerable<NewsCategoryDTO> categories = newsCategoryFacade.GetAll();
            IEnumerable<ProductsDTO> latestproducts = productsFacade.GetLatestProducts();
            IEnumerable<ProductsCategoryDTO> productsCategories = productsCategoryFacade.GetAll();
            IEnumerable<ProductImagesDTO> productImages = productsImageFacade.GetAll();
            NewsViewModel model = new NewsViewModel()
            {
                News = news,
                Categories = categories,
                latestProducts = latestproducts,
                Products = products,
                ProductImages = productImages,
                productsCategories = productsCategories,
            };
            return View(model);
        }
        [HttpPost]
        [ActionName("Index")]
        public IActionResult HomeSearch(string search)
        {
            IEnumerable<ProductsDTO> products = productsFacade.GetAll();
            if (!string.IsNullOrEmpty(search))
            {
                products = productsFacade.HomeSearch(search);
            }
            else
            {
                products = productsFacade.GetAll();
            }
            IEnumerable<ProductsCategoryDTO> productsCategories = productsCategoryFacade.GetAll();
            IEnumerable<ProductImagesDTO> productImages = productsImageFacade.GetAll();
            NewsViewModel model = new NewsViewModel()
            {
                Products = products,
                productsCategories = productsCategories,
                ProductImages = productImages,
            };
            return View("HomeSearch" , model);
        }
        public IActionResult ProductDetails(ProductsCommentDTO Comment ,int id)
        {
            Products product = productsFacade.GetProduct(id);
            IEnumerable<ProductsDTO> productsDTOs = productsFacade.GetAll();
            IEnumerable<ProductsCategoryDTO> categories = productsCategoryFacade.GetAll();
            IEnumerable<ProductsCommentDTO> newsComments = productsCommentFacade.GetComments().Where(a=>a.ProductId == product.ProductId).OrderByDescending(a=>a.PubTime);
            IEnumerable<ProductImagesDTO> productImages = productsImageFacade.GetAll();
            if (Comment.CommentText != null)
            {
                ProductsCommentDTO newscomment = new ProductsCommentDTO()
                {
                    Name = Comment.Name,
                    Email = Comment.Email,
                    CommentText = Comment.CommentText,
                    ProductId = product.ProductId,
                    PubTime = DateTime.Now,
                };
                productsCommentFacade.AddComment(newscomment);
            }
            NewsViewModel products = new NewsViewModel()
            {
                product = product,
                Products = productsDTOs,
                productsCategories = categories,
                productsComments = newsComments,
                ProductImages = productImages,
            };
            return View(products);
        }
        public IActionResult FindByCategory(int categoryId)
        {
            IEnumerable<ProductsDTO> products = productsFacade.FindByCategory(categoryId);
            ProductsCategoryDTO category = productsCategoryFacade.Get(categoryId);
            IEnumerable<ProductsCategoryDTO> productsCategories = productsCategoryFacade.GetAll();
            IEnumerable<ProductImagesDTO> productImages = productsImageFacade.GetAll();
            NewsViewModel model = new NewsViewModel()
            {
                Products = products,
                ProductImages = productImages,
                productsCategories = productsCategories,
                ProductsCategory = category,
            };
            return View(model);
        }
        
        public IActionResult ContactUs()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
