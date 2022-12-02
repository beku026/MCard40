using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCard40.Infrastucture.ViewModels.Doctor;
using MCard40.Model.Entity;

namespace MCard40.Infrastucture.Services.Interfaces
{
    public interface IDoctorService
    {
        void Add(Doctor doctor);
        Doctor GetById(int? id);
        Doctor Update(int id, Doctor doctor);

        IEnumerable<Doctor> GetFiltered(string sortOrder, string searchString);
        Doctor GetDoctorDetails(int? id);
    }
}
