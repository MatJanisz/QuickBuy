using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using QuickBuy.DA.Dto;
using QuickBuy.DA.Interfaces;
using QuickBuy.DA.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuickBuy.DA.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private SignInManager<User> _signManager;
        private UserManager<User> _userManager;
        private readonly IMapper _mapper;
       // private IConfiguration _config;

        public UserRepository(
            ApplicationDbContext context,
            UserManager<User> userManager,
            SignInManager<User> signManager,
           // IConfiguration config
            IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            _signManager = signManager;
          //  _config = config;
            _mapper = mapper;
        }

        public async Task<bool> CreateAsync(AccountRegisterLoginDto model)
        {
            var user = _mapper.Map<User>(model);
            user.UserName = model.Email;

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
                return true;
            return false;
        }

        public Task<string> CreateToken(AccountRegisterLoginDto accountRegisterLoginDto)
        {
            throw new NotImplementedException();
        }
    }
}
