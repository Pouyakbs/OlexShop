using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using OlexShop.Core.ApplicationService.Facade;
using OlexShop.Core.Contracts.Facade;
using OlexShop.Core.Domain.DTOs;
using OlexShop.Core.Domain.Entities;
using OlexShop.Infrastructures.Extensions;
using OlexShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OlexShop.Controllers
{
    public class AccountController : Controller
    {
        public IUserAuthenticationFacade UserAuthenticationFacade { get; set; }
        public IAdminAuthenticationFacade AdminAuthenticationFacade { get; set; }
        public IProductsCategoryFacade productsCategory { get; set; }
        public IWebHostEnvironment WebHostEnvironment { get; set; }
        public IProductsImageFacade ProductsImage { get; set; }

        public AccountController(IUserAuthenticationFacade userAuthenticationFacade , IWebHostEnvironment webHostEnvironment , IAdminAuthenticationFacade AdminAuthenticationFacade,
            IProductsCategoryFacade productsCategory, IProductsImageFacade ProductsImage)
        {
            this.AdminAuthenticationFacade = AdminAuthenticationFacade;
            UserAuthenticationFacade = userAuthenticationFacade;
            this.productsCategory = productsCategory;
            this.ProductsImage = ProductsImage;
            WebHostEnvironment = webHostEnvironment;
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string username, string password, int id)
        {
            foreach (var admin in AdminAuthenticationFacade.GetAuthentications())
            {
                foreach (var user in UserAuthenticationFacade.GetAuthentications())
                {
                    if (admin.Username == username && admin.Password == password)
                    {
                        TempData["AdminLoggedIn"] = "True";
                        return RedirectToAction("Index", "Admin");
                    }
                    else if (user.Username == username && user.Password == password)
                    {
                        TempData["UserLoggedIn"] = "True";
                        return Redirect($"/Account/UserProfile/{user.UsernameId}");
                    }
                    else
                    {
                        TempData["AdminLoggedIn"] = "False";
                        TempData["UserLoggedIn"] = "False";
                    }
                }
            }
            return RedirectToAction("Login");
        }
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SignUp(UserAuthenticationDTO model, string password, string confirmedpass)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = UploadedFile(model);
                UserAuthenticationDTO authentication = new UserAuthenticationDTO
                {
                    Email = model.Email,
                    Username = model.Username,
                    Password = model.Password,
                    ProfileImage = uniqueFileName,
                };
                if (password == confirmedpass)
                {
                    UserAuthenticationFacade.AddUser(authentication);
                }
                else
                {
                    return RedirectToAction("CreateUserAccount");
                }
            }
            return RedirectToAction("Index", "Home");
        }
        private string UploadedFile(UserAuthenticationDTO authentication)
        {
            string uniqueFileName = null;

            if (authentication.Images != null)
            {
                string uploadsFolder = Path.Combine(WebHostEnvironment.WebRootPath, $"images/users");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + authentication.Images.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    authentication.Images.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
        public IActionResult UserProfile(int id)
        {
            var cart = SessionExtension.GetJson<List<CartLine>>(HttpContext.Session, "cart");
            IEnumerable<ProductsCategoryDTO> productsCategories = productsCategory.GetAll();
            UserAuthenticationDTO user = UserAuthenticationFacade.UserProfile(id);
            IEnumerable<ProductImagesDTO> productImages = ProductsImage.GetAll();
            NewsViewModel model = new NewsViewModel()
            {
                ProductImages = productImages,
                Carts = cart,
                User = user,
                productsCategories = productsCategories,
            };
            return View(model);
        }
    }
}
