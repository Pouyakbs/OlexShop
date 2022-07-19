using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using OlexShop.Areas.Admin.Models;
using OlexShop.Core.Contracts.Facade;
using OlexShop.Core.Domain.DTOs;
using OlexShop.Core.Domain.Entities;
using OlexShop.Service;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OlexShop.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        INewsFacade newsFacade;
        IProductsFacade productsFacade;
        IProductsImageFacade productsImageFacade;
        IProductsCategoryFacade productsCategoryFacade;
        INewsCategoryFacade newsCategoryFacade;
        INewsCommentFacade newsCommentFacade;
        IProductsCommentFacade productsCommentFacade;
        IUserAuthenticationFacade userAuthenticationFacade;
        private readonly IViewerCountService viewerCountService;
        public AdminController(INewsFacade newsFacade , IProductsFacade productsFacade , IProductsImageFacade productsImageFacade , 
            INewsCategoryFacade newsCategoryFacade, IViewerCountService viewerCountService , IUserAuthenticationFacade userAuthenticationFacade,
            IProductsCategoryFacade productsCategoryFacade, INewsCommentFacade newsCommentFacade , IProductsCommentFacade productsCommentFacade)
        {
            this.newsFacade = newsFacade;
            this.productsFacade = productsFacade;
            this.productsImageFacade = productsImageFacade;
            this.newsCategoryFacade = newsCategoryFacade;
            this.productsCategoryFacade = productsCategoryFacade;
            this.userAuthenticationFacade = userAuthenticationFacade;
            this.newsCommentFacade = newsCommentFacade;
            this.productsCommentFacade = productsCommentFacade;
            this.viewerCountService = viewerCountService;
        }
        public IActionResult Index()
        {
            var validate = TempData.Peek("AdminLoggedIn");
            if (validate == null || validate.ToString() == "False")
            {
                return RedirectToAction("login", "Account");
            }
            else
            {
                ViewBag.viewerCount = viewerCountService.IncrementViewer();
                IEnumerable<UserAuthenticationDTO> user = userAuthenticationFacade.GetAuthentications().Take(5).OrderByDescending(a => a.UsernameId);
                IEnumerable<ProductsDTO> products = productsFacade.GetAll();
                IEnumerable<NewsDTO> news = newsFacade.GetAll();
                IEnumerable<NewsCommentDTO> newsComments = newsCommentFacade.GetComments();
                IEnumerable<NewsCategoryDTO> newsCategories = newsCategoryFacade.GetAll();
                IEnumerable<ProductsCategoryDTO> productsCategories = productsCategoryFacade.GetAll();
                IEnumerable<ProductsCommentDTO> productsComments = productsCommentFacade.GetComments();
                AdminViewModel model = new AdminViewModel()
                {
                    productsCategories = productsCategories,
                    newsCategories = newsCategories,
                    news = news,
                    Products = products,
                    Comments = newsComments,
                    ProductsComments = productsComments,
                    Users = user,
                };
                return View(model);
            }
        }
        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(ProductsDTO model , ProductImagesDTO ImageFiles, ProductsCategoryDTO productsCategory)
        {
            var validate = TempData.Peek("AdminLoggedIn");
            if (validate == null || validate.ToString() == "False")
            {
                return RedirectToAction("login", "Account");
            }
            else
            {
                if (model.ProductName != null)
                {
                    ProductsDTO products = new ProductsDTO
                    {
                        ProductId = model.ProductId,
                        ProductName = model.ProductName,
                        Brand = model.Brand,
                        Price = model.Price,
                        Quantity = model.Quantity,
                        Color = model.Color,
                        Options = model.Options,
                        Description = model.Description,
                        CategoryName = model.CategoryName,
                        CategoryId = model.CategoryId,
                        ImageId = ImageFiles.ImageId,
                        PubDate = DateTime.Now,
                    };
                    productsFacade.CreateProduct(products);
                }
                else if (ImageFiles.Images != null)
                {
                    UploadedProductsFile(ImageFiles);
                }
                else if (productsCategory.CategoryName != null)
                {
                    productsCategoryFacade.CreateCategory(productsCategory);
                }
                return RedirectToAction(nameof(Index));
            }
        }
        private void UploadedProductsFile(ProductImagesDTO ImageFiles)
        {
            if (ImageFiles != null)
            {
                foreach (var file in ImageFiles.Images)
                {
                    if (file.Length > 0)
                    {
                        //Getting FileName
                        var fileName = Path.GetFileName(file.FileName);

                        //Assigning Unique Filename (Guid)
                        var myUniqueFileName = Convert.ToString(Guid.NewGuid());

                        //Getting file Extension
                        var fileExtension = Path.GetExtension(fileName);

                        // concatenating  FileName + FileExtension
                        var newFileName = String.Concat(myUniqueFileName, fileExtension);

                        // Combines two strings into a path.
                        var filepath =
                        new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "ProductsImages")).Root + $@"\{newFileName}";

                        using (FileStream fs = System.IO.File.Create(filepath))
                        {
                            file.CopyTo(fs);
                            fs.Flush();
                        }


                        using (var image = Bitmap.FromFile(filepath))
                        {
                            using (var tempBitmap = new Bitmap(image))
                            {
                                using (Graphics grp = Graphics.FromImage(tempBitmap))
                                {
                                    image.Dispose();
                                    var logopath = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "logos")).Root + $@"logo-3.png";
                                    var logo = Bitmap.FromFile(logopath);
                                    grp.DrawImage(logo , 0 , 0);
                                    tempBitmap.Save(filepath);
                                }
                            }
                        }
                        
                        ProductImagesDTO productImagesDTO = new ProductImagesDTO()
                        {
                            ImageId = ImageFiles.ImageId,
                            ProductId = ImageFiles.ProductId,
                            ProductImage = newFileName,
                        };
                        productsImageFacade.AddImage(productImagesDTO);

                    }
                }
            }
        }
        public IActionResult ProductsInfo()
        {
            var validate = TempData.Peek("AdminLoggedIn");
            if (validate == null || validate.ToString() == "False")
            {
                return RedirectToAction("login", "Account");
            }
            else
            {
                IEnumerable<ProductsDTO> productsDTO = productsFacade.GetAll().ToList();
                IEnumerable<ProductImagesDTO> productImages = productsImageFacade.GetAll();
                ProductsViewModel products = new ProductsViewModel()
                {
                    Products = productsDTO,
                    ProductImages = productImages
                };
                return View(products);
            }
        }
        public IActionResult AddNews()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddNews(NewsDTO model , NewsCategoryDTO newsCategory)
        {
            var validate = TempData.Peek("AdminLoggedIn");
            if (validate == null || validate.ToString() == "False")
            {
                return RedirectToAction("login", "Account");
            }
            else
            {
                if (model.NewsTitle != null)
                {
                    string uniqueFileName = UploadedFile(model);
                    NewsDTO news = new NewsDTO
                    {
                        NewsTitle = model.NewsTitle,
                        CategoryId = model.CategoryId,
                        NewsText = model.NewsText,
                        NewsSummary = model.NewsSummary,
                        PubDate = DateTime.Now,
                        NewsImages = uniqueFileName
                    };
                    newsFacade.CreateNews(news);
                }
                else if (newsCategory.CategoryName != null)
                {
                    NewsCategoryDTO newsCategoryDTO = new NewsCategoryDTO
                    {
                        CategoryName = newsCategory.CategoryName
                    };
                    newsCategoryFacade.CreateCategory(newsCategoryDTO);
                }
                return RedirectToAction(nameof(Index));
            }
        }
        private string UploadedFile(NewsDTO files)
        {
            string uniqueFileName = null;
            if (files != null)
            {
                foreach (var file in files.Images)
                {
                    if (file.Length > 0)
                    {
                        //Getting FileName
                        var fileName = Path.GetFileName(file.FileName);

                        //Assigning Unique Filename (Guid)
                        var myUniqueFileName = Convert.ToString(Guid.NewGuid());

                        //Getting file Extension
                        var fileExtension = Path.GetExtension(fileName);

                        // concatenating  FileName + FileExtension
                        var newFileName = String.Concat(myUniqueFileName, fileExtension);

                        // Combines two strings into a path.
                        var filepath =
                        new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images" , "NewsImages")).Root + $@"\{newFileName}";

                        using (FileStream fs = System.IO.File.Create(filepath))
                        {
                            file.CopyTo(fs);
                            fs.Flush();
                        }
                        uniqueFileName = newFileName;

                    }
                }
            }
            return uniqueFileName;
        }
        public IActionResult NewsInfo()
        {
            var validate = TempData.Peek("AdminLoggedIn");
            if (validate == null || validate.ToString() == "False")
            {
                return RedirectToAction("login", "Account");
            }
            else
            {
                var news = newsFacade.GetAll();
                return View(news);
            }
            
        }
        public IActionResult EditProduct(int id)
        {
            var validate = TempData.Peek("AdminLoggedIn");
            if (validate == null || validate.ToString() == "False")
            {
                return RedirectToAction("login", "Account");
            }
            else
            {
                Products product = productsFacade.GetProduct(id);
                ProductsViewModel model = new ProductsViewModel()
                {
                    Product = product,
                };
                return View(model);
            }
        }
        [HttpPost]
        public IActionResult EditProduct(Products Products)
        {
            var validate = TempData.Peek("AdminLoggedIn");
            if (validate == null || validate.ToString() == "False")
            {
                return RedirectToAction("login", "Account");
            }
            else
            {
                productsFacade.Edit(Products);
                return RedirectToAction("index");
            }

        }
        public IActionResult EditNews(int id)
        {
            var validate = TempData.Peek("AdminLoggedIn");
            if (validate == null || validate.ToString() == "False")
            {
                return RedirectToAction("login", "Account");
            }
            else
            {
                NewsDTO news = newsFacade.GetNews(id);
                NewsViewModel model = new NewsViewModel()
                {
                    news = news,
                };
                return View(model);
            }
        }
        [HttpPost]
        public IActionResult EditNews(NewsDTO news)
        {
            var validate = TempData.Peek("AdminLoggedIn");
            if (validate == null || validate.ToString() == "False")
            {
                return RedirectToAction("login", "Account");
            }
            else
            {
                newsFacade.Edit(news);
                return RedirectToAction("index");
            }

        }
        public IActionResult DeleteProduct(int id)
        {
            var validate = TempData.Peek("AdminLoggedIn");
            if (validate == null || validate.ToString() == "False")
            {
                return RedirectToAction("login", "Account");
            }
            else
            {
                productsFacade.DeleteProduct(id);
                return RedirectToAction("Index");
            }
            
        }
        public IActionResult DeleteNews(int id)
        {
            var validate = TempData.Peek("AdminLoggedIn");
            if (validate == null || validate.ToString() == "False")
            {
                return RedirectToAction("login", "Account");
            }
            else
            {
                newsFacade.DeleteNews(id);
                return RedirectToAction("Index");
            }
        }
        public IActionResult DeleteComment(int id)
        {
            var validate = TempData.Peek("AdminLoggedIn");
            if (validate == null || validate.ToString() == "False")
            {
                return RedirectToAction("login", "Account");
            }
            else
            {
                productsCommentFacade.DeleteComment(id);
                return RedirectToAction("Index");
            }
        }
        public IActionResult DeleteNewsComment(int id)
        {
            var validate = TempData.Peek("AdminLoggedIn");
            if (validate == null || validate.ToString() == "False")
            {
                return RedirectToAction("login", "Account");
            }
            else
            {
                newsCommentFacade.DeleteComment(id);
                return RedirectToAction("Index");
            }
        }
        public IActionResult DeleteProductCategory(int id)
        {
            var validate = TempData.Peek("AdminLoggedIn");
            if (validate == null || validate.ToString() == "False")
            {
                return RedirectToAction("login", "Account");
            }
            else
            {
                productsCategoryFacade.DeleteCategory(id);
                return RedirectToAction("Index");
            }
        }
        public IActionResult DeleteNewsCategory(int id)
        {
            var validate = TempData.Peek("AdminLoggedIn");
            if (validate == null || validate.ToString() == "False")
            {
                return RedirectToAction("login", "Account");
            }
            else
            {
                newsCategoryFacade.DeleteCategory(id);
                return RedirectToAction("Index");
            }
        }
    }
}
