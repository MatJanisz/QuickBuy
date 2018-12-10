using QuickBuy.DA.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuickBuy.DA.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> Register(AccountRegisterLoginDto model);
        Task<string> Login(AccountRegisterLoginDto accountRegisterLoginDto);
        void AddMoney(float amount, string email);
        float GetMoneyOfLoggedUser(string email);
        void ChangeIsBlockedStatus(string id, string email);
        bool IsLoggedUserBlocked(string email);
        IEnumerable<UserDto> GetAllUsers();
        int GetNumberOfBoughtItems(string id);
    }
}
