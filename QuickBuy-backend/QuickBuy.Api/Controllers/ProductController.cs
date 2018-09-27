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

        [HttpGet("GetProduct/{id}")]
        public IActionResult GetProduct(Guid id)
        {
            var result = _iProductService.GetProduct(id);
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
    }
}