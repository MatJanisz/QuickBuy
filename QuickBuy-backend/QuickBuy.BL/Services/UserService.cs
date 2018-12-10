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
            return await _userRepository.Register(accountDto);
        }

        public void AddMoney(float amount, string email)
        {
            _userRepository.AddMoney(amount, email);
        }

        public Task<string> Login(AccountRegisterLoginViewModel model)
        {
            var accountDto = _mapper.Map<AccountRegisterLoginDto>(model);
            var result = _userRepository.Login(accountDto);
            return result;
        }

        public void ChangeIsBlockedStatus(string id, string email)
        {
            _userRepository.ChangeIsBlockedStatus(id, email);
        }

        public float GetMoneyOfLoggedUser(string email)
        {
            return _userRepository.GetMoneyOfLoggedUser(email);
        }

        public bool IsLoggedUserBlocked(string email)
        {
            return _userRepository.IsLoggedUserBlocked(email);
        }

        public IEnumerable<UserViewModel> GetAllUsers()
        {
            var users = _userRepository.GetAllUsers();
            var result = _mapper.Map<List<UserViewModel>>(users);
            foreach(var user in result)
            {
                user.NumberOfBoughtItems = _userRepository.GetNumberOfBoughtItems(user.Id.ToString());
            }
            return result;
        }

    }
}
