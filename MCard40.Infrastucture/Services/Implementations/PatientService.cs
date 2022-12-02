using MCard40.Infrastucture.Services.Interfaces;
using MCard40.Model.Entity;
using MCard40.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCard40.Infrastucture.Services.Implementations
{
    public class PatientService : IPatientService
    {
        private readonly IRepository<Patient> _repository;

        public PatientService(
           IRepository<Patient> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Patient> GetFiltered(string sortOrder, string searchString)
        {
            var patients = _repository.Get();
            if (!String.IsNullOrEmpty(searchString))
            {
                patients = patients
                    .Where(s => s.FullName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    patients = patients.OrderByDescending(s => s.FullName);
                    break;
                case "Date":
                    patients = patients.OrderBy(s => s.Age);
                    break;
                default:
                    patients = patients.OrderBy(s => s.FullName);
                    break;
            }

            return patients;
        }
        public Patient GetDoctorDetails(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var patient = _repository.GetById(id.Value);
            return patient; 
        }
    }
}
