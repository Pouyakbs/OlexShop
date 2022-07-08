using OlexShop.Core.Domain.DTOs;
using OlexShop.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlexShop.Areas.Admin.Models
{
    public class NewsViewModel
    {
        public List<News> News { get; set; }
        public NewsDTO news { get; set; }
    }
}
