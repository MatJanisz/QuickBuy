using AutoMapper;
using QuickBuy.BL.Interfaces;
using QuickBuy.BL.ViewModel;
using QuickBuy.DA.Dto;
using QuickBuy.DA.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBuy.BL.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public IEnumerable<ProductViewModel> GetAll()
        {
            var result = _productRepository.GetAll();
            return _mapper.Map<List<ProductViewModel>>(result);
        }

        public IEnumerable<ProductViewModel> GetProductsByName(string name)
        {
            var result = _productRepository.GetProductsByName(name);
            return _mapper.Map<List<ProductViewModel>>(result);
        }

        public IEnumerable<ProductViewModel> GetProductsByCategory(string category)
        {
            var result = _productRepository.GetProductsByCategory(category);
            return _mapper.Map<List<ProductViewModel>>(result);
        }

        public IEnumerable<ProductViewModel> GetProductsByNameAndCategory(string name, string category)
        {
            var result = _productRepository.GetProductsByNameAndCategory(name, category);
            return _mapper.Map<List<ProductViewModel>>(result);
        }

        public IEnumerable<ProductViewModel> GetRandomProducts(int howMany)
        {
            var result = _productRepository.GetRandomProducts(howMany);
            return _mapper.Map<List<ProductViewModel>>(result);
        }

        public ProductViewModel GetProduct(Guid id)
        {
            var productDto =_productRepository.GetProduct(id);
            var result = _mapper.Map<ProductViewModel>(productDto);
            return result;
        }

        public IEnumerable<ProductViewModel> GetAllMyProducts(string email)
        {
            var result = _productRepository.GetAllMyProducts(email);
            return _mapper.Map<List<ProductViewModel>>(result);
        }

        public IEnumerable<ProductViewModel> GetAllMyBoughtProducts(string email)
        {
            var result = _productRepository.GetAllMyBoughtProducts(email);
            return _mapper.Map<List<ProductViewModel>>(result);
        }

        public void AddProduct(ProductViewModel newProduct, string email)
        {
            var productDtoObject = _mapper.Map<ProductDto>(newProduct);
            _productRepository.AddProduct(productDtoObject, email);
        }

        public void EditProduct(ProductViewModel editedProduct, string email)
        {
            var productDtoObject = _mapper.Map<ProductDto>(editedProduct);
            _productRepository.EditProduct(productDtoObject, email);
        }

        public void DeleteProduct(Guid id)
        {
            _productRepository.DeleteProduct(id);
        }

        public string BuyProduct(Guid id, int howMany, string email)
        {
            var result = _productRepository.BuyProduct(id, howMany, email);
            return result;
        }
    }
}
