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

        public ProductViewModel GetProduct(Guid id)
        {
            var productDto =_productRepository.GetProduct(id);
            var result = _mapper.Map<ProductViewModel>(productDto);
            return result;
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
    }
}
