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
    }
}
