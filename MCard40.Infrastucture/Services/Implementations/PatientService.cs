using MCard40.Infrastucture.Services.Interfaces;
using MCard40.Model.Entity;
using MCard40.Model.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MCard40.Infrastucture.Services.Implementations
{
    public class PatientService : IPatientService
    {
        private readonly IRepository<Patient, int> _repository;

        public PatientService(
           IRepository<Patient, int> repository)
        {
            _repository = repository;
        }
        public void Add(Patient patient)
        {
            _repository.Create(patient);
        }
        public Patient GetById(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var patient = _repository.ReadById(id.Value);

            return patient;
        }
        public Patient Update(int id, Patient patient)
        {
            try
            {
                _repository.Update(patient);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_repository.IsExists(patient.Id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
            return patient;
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
        public Patient GetPatientDetails(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var patient = _repository.ReadById(id.Value);
            return patient; 
        }
        public Patient Delete(int id)
        {
            var patient = _repository.DeleteById(id);
            if (patient == null)
            {
                return null;
            }

            return patient;
        }

    }
}
