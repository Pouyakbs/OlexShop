using OlexShop.Core.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace OlexShop.Core.Contracts.Facade
{
    public interface IProductsImageFacade
    {
        public IEnumerable<ProductImagesDTO> GetAll();
        public void AddImage(ProductImagesDTO productImages);
        public void DeleteImage(int id);
    }
}
