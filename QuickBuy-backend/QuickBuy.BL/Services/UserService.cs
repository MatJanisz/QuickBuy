using AutoMapper;
using QuickBuy.BL.Interfaces;
using QuickBuy.BL.ViewModel;
using QuickBuy.DA.Dto;
using QuickBuy.DA.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuickBuy.BL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<bool> Create(AccountRegisterLoginViewModel model)
        {
            var accountDto = _mapper.Map<AccountRegisterLoginDto>(model);
            return await _userRepository.CreateAsync(accountDto);
        }

        public void AddMoney(float amount, string email)
        {
            _userRepository.AddMoney(amount, email);
        }

        public Task<string> Login(AccountRegisterLoginViewModel model)
        {
            var accountDto = _mapper.Map<AccountRegisterLoginDto>(model);
            var result = _userRepository.CreateToken(accountDto);
            return result;
        }
    }
}
