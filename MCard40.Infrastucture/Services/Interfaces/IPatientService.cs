using MCard40.Infrastucture.ViewModels.Patient;
using MCard40.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCard40.Infrastucture.Services.Interfaces
{
    public interface IPatientService
    {
        void Add(Patient patient);
        Patient GetById(int? id);
        Patient Update(int id, Patient patient);
        IEnumerable<Patient> GetFiltered(string sortOrder, string searchString);
        Patient GetPatientDetails(int? id);
        Patient Delete(int id);
    }
}
