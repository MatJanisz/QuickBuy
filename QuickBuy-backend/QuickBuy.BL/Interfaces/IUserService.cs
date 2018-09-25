using QuickBuy.BL.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuickBuy.BL.Interfaces
{
    public interface IUserService
    {
        Task<bool> Create(AccountRegisterLoginViewModel model);
        Task<string> CreateToken(AccountRegisterLoginViewModel accountRegisterLoginViewModel);
    }
}
