using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuickBuy.DA.Dto;
using QuickBuy.DA.Interfaces;
using QuickBuy.DA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickBuy.DA.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<ProductDto> GetAll()
        {
            var result = _context.Products.Include(u => u.User);
            return _mapper.Map<List<ProductDto>>(result);
        }

        public IEnumerable<ProductDto> GetProductsByName(string name)
        {
            var result = _context.Products.Where(n => n.Name.Contains(name));
            return _mapper.Map<List<ProductDto>>(result);
        }

        public IEnumerable<ProductDto> GetProductsByCategory(string category)
        {
            var result = _context.Products.Include(u => u.User).Where(n => n.Category.ToString() == category);
            return _mapper.Map<List<ProductDto>>(result);
        }

        public IEnumerable<ProductDto> GetProductsByNameAndCategory(string name, string category)
        {
            var result = _context.Products.Include(u => u.User).Where((n => n.Name.Contains(name)
            && n.Category.ToString() == category));
            return _mapper.Map<List<ProductDto>>(result);
        }

        public ProductDto GetProduct(Guid id)
        {
            var product = _context.Products.Include(u => u.User).Single(n => n.Id == id);
            var result = _mapper.Map<ProductDto>(product);
            return result;
        }

        public void AddProduct(ProductDto newProduct, string email)
        {
            var productObject = _mapper.Map<Product>(newProduct);
            var user = _context.Users.Single(u => u.Email == email);
            productObject.OwnerId = user.Id;
            _context.Products.Add(productObject);
            _context.SaveChanges();
        }

        public void EditProduct(ProductDto editedProduct, string email)
        {
            var productObject = _mapper.Map<Product>(editedProduct);
            var productInDb = _context.Products.Single(n => n.Id == productObject.Id);
            var user = _context.Users.Single(u => u.Email == email);
            if(productInDb.OwnerId == user.Id)
            {
                _context.Entry(productInDb).CurrentValues.SetValues(productObject);
                _context.SaveChanges();
            }
        }

        public void DeleteProduct(Guid id)
        {
            var productInDb = _context.Products.Single(n => n.Id == id);
            _context.Products.Remove(productInDb);
            _context.SaveChanges();
        }
    }
}
