using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MCard40.Infrastucture.ViewModels.CardPage;
using MCard40.Model.Entity;

namespace MCard40.Infrastucture.Profiles;
public class CardPageProfile : Profile
{
    public CardPageProfile()
    {
        CreateMap<CardPage, CardPageVM>().ReverseMap();
    }
}
