using AutoMapper;
using QuickBuy.DA.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBuy.DA.Dto
{
    public class MappingProfileDto : Profile
    {
        public MappingProfileDto()
        {
            CreateMap<AccountRegisterLoginDto, User>().ReverseMap();
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.OwnerEmail, opt => opt.MapFrom(src => src.User.Email));
               // .ReverseMap();
        }
    }
}
