using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBuy.DA.Dto
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public float AmountOfMoney { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsBlocked { get; set; }
    }
}
