using MCard40.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCard40.Infrastucture.Services.Interfaces
{
    public interface IWeekService
    {
        public IEnumerable<Week> GetAll(int id);
        void Add(Week week);
        Week GetById(int? id);
        Week Update(int id, Week week);
        Week GetWeekDetails(int? id);
        Week Delete(int id);
    }
}
