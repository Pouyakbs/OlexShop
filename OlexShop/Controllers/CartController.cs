using Microsoft.AspNetCore.Mvc;
using OlexShop.Core.Contracts.Facade;
using OlexShop.Core.Domain.DTOs;
using OlexShop.Core.Domain.Entities;
using OlexShop.Infrastructures.Extensions;
using OlexShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlexShop.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductsFacade productsFacade;
        IProductsImageFacade productsImageFacade;
        private readonly Cart cart;

        public CartController(IProductsFacade productsFacade, Cart cart , IProductsImageFacade productsImageFacade)
        {
            this.productsFacade = productsFacade;
            this.cart = cart;
            this.productsImageFacade = productsImageFacade;
        }
        public IActionResult Index()
        {
            var cart = SessionExtension.GetJson<List<CartLine>>(HttpContext.Session, "cart");
            if (cart != null)
            {
                IEnumerable<ProductImagesDTO> productImages = productsImageFacade.GetAll();
                NewsViewModel model = new NewsViewModel()
                {
                    Carts = cart,
                    TotalPrice = cart.Sum(item => item.Product.Price * item.Quantity),
                    ProductImages = productImages,
                };
                return View(model);
            }
            return View();
        }
        [Route("buy/{id}")]
        public IActionResult Buy(int id)
        {
            Products products = productsFacade.GetProduct(id);
            ProductsViewModel productModel = new ProductsViewModel()
            {
                Products = products
            };
            if (SessionExtension.GetJson<List<CartLine>>(HttpContext.Session, "cart") == null)
            {
                List<CartLine> cart = new List<CartLine>();
                cart.Add(new CartLine { Product = productsFacade.GetProduct(id), Quantity = 1 });
                SessionExtension.SetJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<CartLine> cart = SessionExtension.GetJson<List<CartLine>>(HttpContext.Session, "cart");
                int index = isExist(id);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new CartLine { Product = productsFacade.GetProduct(id), Quantity = 1 });
                }
                SessionExtension.SetJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("Index");
        }

        [Route("remove/{id}")]
        public IActionResult Remove(int id)
        {
            List<CartLine> cart = SessionExtension.GetJson<List<CartLine>>(HttpContext.Session, "cart");
            int index = isExist(id);
            cart.RemoveAt(index);
            SessionExtension.SetJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }

        private int isExist(int id)
        {
            List<CartLine> cart = SessionExtension.GetJson<List<CartLine>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.ProductId.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }

    }
}
