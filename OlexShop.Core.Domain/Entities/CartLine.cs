using OlexShop.Core.Domain.DTOs;
using System;
using System.Text;

namespace OlexShop.Core.Domain.Entities
{
    public class CartLine
    {
        public int CartLineId { get; set; }
        public Products Product { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
