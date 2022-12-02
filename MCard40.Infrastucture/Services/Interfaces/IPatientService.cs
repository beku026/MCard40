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
        IEnumerable<Patient> GetFiltered(string sortOrder, string searchString);
        Patient GetDoctorDetails(int? id);
    }
}
