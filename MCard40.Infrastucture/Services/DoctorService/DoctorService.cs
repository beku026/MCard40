using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MCard40.Infrastucture.ViewModels.Doctor;
using MCard40.Model.Entity;
using MCard40.Model.Interfaces;

namespace MCard40.Infrastucture.Services.DoctorService
{
    public class DoctorService : IDoctorSrevice
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Doctor> _doctorRep;
        private Doctor _doctor;
        public DoctorService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public Task Create(DoctorVM model)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task Edit(int id, DoctorVM model)
        {
            throw new NotImplementedException();
        }
    }
}
