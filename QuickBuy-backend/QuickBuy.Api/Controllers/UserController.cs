using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpPost("Login")]
        public IActionResult Login([FromBody] AccountRegisterLoginViewModel model)
        {
            var tokenstring = _iUserService.Login(model);
            return Ok(new { token = tokenstring.Result });
        }

        [Authorize]
        public int Get()
        {
            return 5;
        }
    }
}