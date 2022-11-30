using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MCard40.Infrastucture.ViewModels.Patient;
using MCard40.Model.Entity;

namespace MCard40.Infrastucture.Profiles;
public class PatientProfile : Profile
{
    public PatientProfile()
    {
        CreateMap<Patient, PatientVM>().ReverseMap();
    }
}
