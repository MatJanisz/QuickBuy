using QuickBuy.DA.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBuy.DA.Interfaces
{
    public interface IProductRepository
    {
        void AddProduct(ProductDto newProduct, string email);
        void EditProduct(ProductDto editedProduct, string email);
        void DeleteProduct(Guid id);
        ProductDto GetProduct(Guid id);
        IEnumerable<ProductDto> GetAll();
        IEnumerable<ProductDto> GetProductsByName(string name);
        IEnumerable<ProductDto> GetProductsByCategory(string category);
        IEnumerable<ProductDto> GetProductsByNameAndCategory(string name, string category);
    }
}
