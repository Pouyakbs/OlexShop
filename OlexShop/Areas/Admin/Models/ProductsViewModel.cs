using OlexShop.Core.Domain.DTOs;
using OlexShop.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlexShop.Areas.Admin.Models
{
    public class ProductsViewModel
    {
        public IEnumerable<ProductsDTO> Products { get; set; }
        public IEnumerable<ProductImagesDTO> ProductImages { get; set; }
        public Products Product { get; set; }
    }
}
