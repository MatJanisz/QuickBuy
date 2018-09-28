using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuickBuy.BL.Interfaces;
using QuickBuy.BL.ViewModel;

namespace QuickBuy.Api.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _iUserService;
        private readonly IMapper _mapper;
        //private IConfiguration _config;

        public UserController(IUserService iUserService, IMapper mapper /*IConfiguration config*/)
        {
            _iUserService = iUserService;
            _mapper = mapper;
          //  _config = config;
        }

        [HttpPost("Register")]
        public IActionResult Register([FromBody] AccountRegisterLoginViewModel model)
        {
            var result =_iUserService.Create(model);
            if (result.Result == true)
                return Ok();
            return BadRequest();
        }

        [HttpGet("AddMoney/{amount}")]
        public IActionResult AddMoney(float amount)
        {
            var currentUser = HttpContext.User;
            var email = currentUser.Claims.First(c => c.Type == ClaimTypes.Email).Value;
            _iUserService.AddMoney(amount, email);
            return Ok();
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] AccountRegisterLoginViewModel model)
        {
            var tokenstring = _iUserService.Login(model);
            return Ok(new { token = tokenstring.Result });
        }

        [HttpGet("GetEmailOfLoggedUser"), Authorize]
        public IActionResult GetEmailOfLoggedUser()
        {
            var currentUser = HttpContext.User;
            var email = currentUser.Claims.First(c => c.Type == ClaimTypes.Email).Value;
            return Ok(email);
        }

        [HttpGet("IsLoggedUserAdmin"), Authorize]
        public IActionResult IsLoggedUserAdmin()
        {
            var currentUser = HttpContext.User;
            var email = currentUser.Claims.First(c => c.Type == ClaimTypes.Role).Value;
            return Ok(email);
        }

        [HttpGet("GetMoneyOfLoggedUser"), Authorize]
        public IActionResult GetMoneyOfLoggedUser()
        {
            var currentUser = HttpContext.User;
            var email = currentUser.Claims.First(c => c.Type == ClaimTypes.Email).Value;
            return Ok(_iUserService.GetMoneyOfLoggedUser(email));
        }

        [HttpGet, Authorize]
        public int Get()
        {
            return 5;
        }
    }
}