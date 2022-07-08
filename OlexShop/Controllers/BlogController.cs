using Microsoft.AspNetCore.Mvc;
using OlexShop.Core.Contracts.Facade;
using OlexShop.Core.Domain.DTOs;
using OlexShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlexShop.Controllers
{
    public class BlogController : Controller
    {
        INewsFacade newsFacade;
        INewsCategoryFacade NewsCategory;
        INewsCommentFacade newsCommentFacade;
        public BlogController(INewsFacade newsFacade , INewsCategoryFacade NewsCategory, INewsCommentFacade newsCommentFacade)
        {
            this.newsFacade = newsFacade;
            this.NewsCategory = NewsCategory;
            this.newsCommentFacade = newsCommentFacade;
        }
        public IActionResult Index(int categoryId, string search)
        {
            IEnumerable<NewsDTO> news = new List<NewsDTO>();
            if (!string.IsNullOrEmpty(search))
            {
                news = newsFacade.HomeSearch(search);
            }
            else if (categoryId != 0)
            {
                news = newsFacade.FindByCategory(categoryId);
            }
            else
            {
                news = newsFacade.GetAll();
            }
            IEnumerable<NewsCategoryDTO> categories = NewsCategory.GetAll();
            List<NewsCategoryViewModel> categoryViewModels = new List<NewsCategoryViewModel>();
            foreach (var item in categories)
            {
                NewsCategoryViewModel vm = new NewsCategoryViewModel();
                vm.CategoryId = item.CategoryId;
                vm.Title = item.Title;
                vm.CategoryName = item.CategoryName;
                vm.NewsCount = item.News.Count();
                categoryViewModels.Add(vm);
            }
            NewsViewModel model = new NewsViewModel()
            {
                News = news,
                CategoriesViewModel = categoryViewModels,

            };
            return View(model);
        }
        public IActionResult NewsDetails(int id)
        {
            NewsDTO news = newsFacade.GetNews(id);
            IEnumerable<NewsDTO> newsList = newsFacade.GetAll();
            IEnumerable<NewsCategoryDTO> categories = NewsCategory.GetAll();
            IEnumerable<NewsCommentDTO> newsComments = newsCommentFacade.GetComments().Where(a=>a.NewsId == id);
            NewsViewModel model = new NewsViewModel()
            {
                NewsDTO = news,
                News = newsList,
                Categories = categories,
                Comments = newsComments,
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult NewsDetails(NewsCommentDTO Comment , int id)
        {
            NewsDTO news = newsFacade.GetNews(id);
            IEnumerable<NewsDTO> newsList = newsFacade.GetAll();
            IEnumerable<NewsCategoryDTO> categories = NewsCategory.GetAll();
            IEnumerable<NewsCommentDTO> newsComments = newsCommentFacade.GetComments().Where(a=>a.NewsId == news.NewsId).OrderByDescending(a => a.PubTime);
            if (Comment.CommentText != null)
            {
                NewsCommentDTO newscomment = new NewsCommentDTO()
                {
                    Name = Comment.Name,
                    Email = Comment.Email,
                    CommentText = Comment.CommentText,
                    NewsId = news.NewsId,
                    PubTime = DateTime.Now,
                };
                newsCommentFacade.AddComment(newscomment);
            }
            NewsViewModel model = new NewsViewModel()
            {
                NewsDTO = news,
                News = newsList,
                Categories = categories,
                Comments = newsComments,
            };
            return View(model);
        }
    }
}
