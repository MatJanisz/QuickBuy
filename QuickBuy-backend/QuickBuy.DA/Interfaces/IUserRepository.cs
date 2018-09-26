using QuickBuy.DA.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuickBuy.DA.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> CreateAsync(AccountRegisterLoginDto model);
        Task<string> CreateToken(AccountRegisterLoginDto accountRegisterLoginDto);
        void AddMoney(float amount, string email);
    }
}
