using AutoMapper;
using QuickBuy.DA.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBuy.BL.ViewModel
{
    public class MappingProfileViewModel : Profile
    {
        public MappingProfileViewModel()
        {
            CreateMap<AccountRegisterLoginViewModel, AccountRegisterLoginDto>().ReverseMap();
            CreateMap<ProductViewModel, ProductDto>().ReverseMap();
        }
    }
}
