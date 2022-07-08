using OlexShop.Core.Domain.DTOs;
using OlexShop.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlexShop.Models
{
    public class ProductsViewModel
    {
        public Products Products { get; set; }
        public IEnumerable<ProductsDTO> products { get; set; }
        public IEnumerable<ProductsCategory> Categories { get; set; }
        public IEnumerable<ProductsComment> Comments { get; set; }
        public IEnumerable<ProductImages> ProductImages { get; set; }
        public IEnumerable<UserAuthentication> UserAuthentications { get; set; }

    }
}
