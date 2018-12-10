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
using QuickBuy.DA.Models;

namespace QuickBuy.Api.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _iUserService;
        private readonly IMapper _mapper;

        public UserController(IUserService iUserService, IMapper mapper)
        {
            _iUserService = iUserService;
            _mapper = mapper;
        }

        [HttpPost("Register")]
        public IActionResult Register([FromBody] AccountRegisterLoginViewModel model)
        {
            var result =_iUserService.Create(model);
            if (result.Result == true)
                return Ok();
            return BadRequest();
        }

        [HttpPost("AddMoney/{money}"), Authorize]
        public IActionResult AddMoney(float money)
        {
            var currentUser = HttpContext.User;
            var email = currentUser.Claims.First(c => c.Type == ClaimTypes.Email).Value;
            _iUserService.AddMoney(money, email);
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
            var result = currentUser.Claims.First(c => c.Type == ClaimTypes.Role).Value;
            return Ok(result);
        }

        [HttpGet("IsLoggedUserBlocked"), Authorize]
        public IActionResult IsLoggedUserBlocked()
        {
            var currentUser = HttpContext.User;
            var email = currentUser.Claims.First(c => c.Type == ClaimTypes.Email).Value;
            return Ok(_iUserService.IsLoggedUserBlocked(email).ToString());
        }

        [HttpGet("GetMoneyOfLoggedUser"), Authorize]
        public IActionResult GetMoneyOfLoggedUser()
        {
            var currentUser = HttpContext.User;
            var email = currentUser.Claims.First(c => c.Type == ClaimTypes.Email).Value;
            return Ok(_iUserService.GetMoneyOfLoggedUser(email));
        }

        [HttpGet("GetDataOfLoggedUser"), Authorize]
        public IActionResult GetDataOfLoggedUser()
        {
            var currentUser = HttpContext.User;
            var email = currentUser.Claims.First(c => c.Type == ClaimTypes.Email).Value;
            var isAdmin = currentUser.Claims.First(c => c.Type == ClaimTypes.Role).Value;
            var money = currentUser.Claims.First(c => c.Type == ClaimTypes.Email).Value.ToString();
            var user = new User
            {
                Email = email
             //   IsAdmin = isAdmin == "true",
              //  AmountOfMoney = float.Parse(money)
            };
            return Ok(user);
        }

        [HttpGet("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            return Ok(_iUserService.GetAllUsers());
        }

        [HttpPost("ChangeIsBlockedStatus/{id}"), Authorize]
        public void ChangeIsBlockedStatus(string id)
        {
            var currentUser = HttpContext.User;
            var email = currentUser.Claims.First(c => c.Type == ClaimTypes.Email).Value;
            _iUserService.ChangeIsBlockedStatus(id, email);
        }


        [HttpPost, Authorize]
        public int Get()
        {
            return 5;
        }
    }
}