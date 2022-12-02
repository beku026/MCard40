using AutoMapper;
using MCard40.Infrastucture.Services.Interfaces;
using MCard40.Infrastucture.ViewModels.Doctor;
using MCard40.Model.Entity;
using MCard40.Model.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MCard40.Infrastucture.Services.Implementations
{
    public class DoctorService : IDoctorService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Doctor> _repository;
        public DoctorService(
            IRepository<Doctor> repository)
        {
            _repository = repository;
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

        public IEnumerable<Doctor> GetFiltered(string sortOrder, string searchString)
        {
            var doctors = _repository.Get();
            if (!String.IsNullOrEmpty(searchString))
            {
                doctors = doctors
                    .Where(s => s.FullName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    doctors = doctors.OrderByDescending(s => s.FullName);
                    break;
                case "Date":
                    doctors = doctors.OrderBy(s => s.Age);
                    break;
                default:
                    doctors = doctors.OrderBy(s => s.FullName);
                    break;
            }

            return doctors;
        }
        public Doctor GetDoctorDetails(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var doctor = _repository.GetById(id.Value);
            return doctor; 
        }
    }
}
