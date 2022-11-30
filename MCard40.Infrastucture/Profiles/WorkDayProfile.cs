using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MCard40.Infrastucture.ViewModels.WeekWorkDay;
using MCard40.Model.Entity;

namespace MCard40.Infrastucture.Profiles;
public class WorkDayProfile : Profile
{
    public WorkDayProfile()
    {
        CreateMap<WorkDay, WorkDayVM>().ReverseMap();
    }
}
