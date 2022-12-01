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
        Task Create(DoctorVM model);
        Task Delete(int id);
        Task Edit(int id, DoctorVM model);
        IEnumerable<Doctor> GetFiltered(string sortOrder, string searchString);
    }
}
