using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBuy.DA.Dto
{
    public class AccountRegisterLoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public float? AmountOfMoney { get; set; }
    }
}
