using QuickBuy.BL.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBuy.BL.Interfaces
{
    public interface IProductService
    {
        void AddProduct(ProductViewModel newProduct, string email);
        void EditProduct(ProductViewModel editedProduct, string email);
        void DeleteProduct(Guid id);
        ProductViewModel GetProduct(Guid id);
        IEnumerable<ProductViewModel> GetAll();
        IEnumerable<ProductViewModel> GetProductsByName(string name);
        IEnumerable<ProductViewModel> GetProductsByCategory(string category);
        IEnumerable<ProductViewModel> GetProductsByNameAndCategory(string name, string category);
        IEnumerable<ProductViewModel> GetRandomProducts(int howMany);
        string BuyProduct(Guid id, int howMany, string email);
        IEnumerable<ProductViewModel> GetAllMyProducts(string email);
        IEnumerable<ProductViewModel> GetAllMyBoughtProducts(string email);
    }
}
