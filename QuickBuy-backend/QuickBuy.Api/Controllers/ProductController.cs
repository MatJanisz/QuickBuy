using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuickBuy.BL.Interfaces;
using QuickBuy.BL.ViewModel;

namespace QuickBuy.Api.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _iProductService;
        private readonly IMapper _mapper;
        //private IConfiguration _config;

        public ProductController(IProductService iProductService, IMapper mapper /*IConfiguration config*/)
        {
            _iProductService = iProductService;
            _mapper = mapper;
            //  _config = config;
        }

        [HttpGet()]
        public IActionResult GetAll()
        {
            var result = _iProductService.GetAll();
            return Ok(result);
        }

        [HttpGet("GetProduct/{id}")]
        public IActionResult GetProduct(Guid id)
        {
            var result = _iProductService.GetProduct(id);
            return Ok(result);
        }

        [HttpGet("GetProductsByName/{name}")]
        public IActionResult GetProductsByName(string name)
        {
            var result = _iProductService.GetProductsByName(name);
            return Ok(result);
        }

        [HttpGet("GetProductsByCategory/{category}")]
        public IActionResult GetProductsByCategory(string category)
        {
            var result = _iProductService.GetProductsByCategory(category);
            return Ok(result);
        }

        [HttpGet("GetProductsByNameAndCategory/{name}/{category}")]
        public IActionResult GetProductsByNameAndCategory(string name, string category)
        {
            var result = _iProductService.GetProductsByNameAndCategory(name, category);
            return Ok(result);
        }

        [HttpGet("GetAllMyProducts")]
        public IActionResult GetAllMyProducts()
        {
            var email = HttpContext.User.Claims.First(c => c.Type == ClaimTypes.Email).Value;
            var result = _iProductService.GetAllMyProducts(email);
            return Ok(result);
        }

        [HttpGet("GetAllMyBoughtProducts")]
        public IActionResult GetAllMyBoughtProducts()
        {
            var email = HttpContext.User.Claims.First(c => c.Type == ClaimTypes.Email).Value;
            var result = _iProductService.GetAllMyBoughtProducts(email);
            return Ok(result);
        }

        [HttpPost, Authorize]
        public IActionResult AddProduct([FromBody] ProductViewModel newProduct)
        {
            var email = HttpContext.User.Claims.First(c => c.Type == ClaimTypes.Email).Value;
            _iProductService.AddProduct(newProduct, email);
            return Ok();
        }

        [HttpPut, Authorize]
        public IActionResult EditProduct([FromBody] ProductViewModel editedProduct)
        {
            var email = HttpContext.User.Claims.First(c => c.Type == ClaimTypes.Email).Value;
            _iProductService.EditProduct(editedProduct, email);
            return Ok();
        }

        [HttpDelete("{id}"), Authorize]
        public IActionResult DeleteProduct(Guid id)
        {
            var isAdmin = HttpContext.User.Claims.First(c => c.Type == ClaimTypes.Role).Value;
            if(isAdmin.ToLower() == "true")
            {
                _iProductService.DeleteProduct(id);
                return Ok();
            }
            return Unauthorized();
        }

        [HttpPost("BuyProduct/{id}/{howMany}"), Authorize]
        public IActionResult BuyProduct(Guid id, int howMany)
        {
            var email = HttpContext.User.Claims.First(c => c.Type == ClaimTypes.Email).Value;
            var result = _iProductService.BuyProduct(id, howMany, email);
            return Ok(result);
        }
    }
}