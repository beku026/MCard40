using MCard40.Infrastucture.Services.Interfaces;
using MCard40.Model.Entity;
using MCard40.Model.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MCard40.Infrastucture.Services.Implementations
{
    public class WeekService : IWeekService
    {
        private readonly IRepository<Week, int> _repository;

        public WeekService(IRepository<Week, int> repository)
        {
            _repository = repository;
        }
        public void Add(Week week)
        {
            _repository.Create(week);
        }

        public Week Delete(int id)
        {
            var week = _repository.DeleteById(id);
            if (week == null)
            {
                return null;
            }

            return week;
        }

        public IEnumerable<Week> GetAll(int id)
        {
            return _repository.GetWithInclude(x => x.Id == id,
													   y => y.WorkDays);
        }


		public Week GetById(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var week = _repository.ReadById(id.Value);

            return week;
        }

        public Week GetWeekDetails(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var week = _repository.ReadById(id.Value);
            return week;
        }

        public Week Update(int id, Week week)
        {
            try
            {
                _repository.Update(week);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_repository.IsExists(week.Id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
            return week;
        }
    }
}
