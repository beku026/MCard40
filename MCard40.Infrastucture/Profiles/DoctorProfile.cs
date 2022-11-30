using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MCard40.Infrastucture.ViewModels.Doctor;
using MCard40.Model.Entity;

namespace MCard40.Infrastucture.Profiles;
public class DoctorProfile : Profile
{
    public DoctorProfile()
    {
        CreateMap<Doctor, DoctorVM>().ReverseMap();
    }
}
