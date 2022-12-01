using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCard40.Infrastucture.ViewModels.Doctor;

namespace MCard40.Infrastucture.Services.DoctorService
{
    public interface IDoctorSrevice
    {
        Task Create(DoctorVM model);
        Task Delete(int id);
        Task Edit(int id, DoctorVM model);
    }
}
