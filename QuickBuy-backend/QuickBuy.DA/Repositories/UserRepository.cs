using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using QuickBuy.DA.Dto;
using QuickBuy.DA.Interfaces;
using QuickBuy.DA.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
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
        private IConfiguration _config;

        public UserRepository(
            ApplicationDbContext context,
            UserManager<User> userManager,
            SignInManager<User> signManager,
            IConfiguration config,
            IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            _signManager = signManager;
            _config = config;
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

        public async Task<string> CreateToken(AccountRegisterLoginDto accountRegisterLoginDto)
        {
            var user = await _userManager.FindByEmailAsync(accountRegisterLoginDto.Email);
            if (user == null)
            {
                return "Your login or password is incorrect";
            }
            var signInResult = await _signManager.CheckPasswordSignInAsync(user, accountRegisterLoginDto.Password, false);
            if (!signInResult.Succeeded)
            {
                return "Your login or password is incorrect";
            }
            return BuildToken(user);
        }

        private string BuildToken(User user)
        {

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Typ, user.IsAdmin.ToString()),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(30),
              signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
