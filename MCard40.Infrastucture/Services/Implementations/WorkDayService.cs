using MCard40.Infrastucture.Services.Interfaces;
using MCard40.Infrastucture.ViewModels.WeekWorkDay;
using MCard40.Model.Entity;
using MCard40.Model.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace MCard40.Infrastucture.Services.Implementations
{
    public class WorkDayService : IWorkDayService
    {
        private readonly IRepository<WorkDay, int> _repository;
        public WorkDayService(IRepository<WorkDay, int> repository)
        {
            _repository = repository;
        }
        public void Add(WorkDay workDay)
        {
            _repository.Create(workDay);
        }

        public WorkDay Delete(int id)
        {
            var workDay = _repository.DeleteById(id);
            if (workDay == null)
            {
                return null;
            }

            return workDay;
        }

        public List<WorkDay> GetAll()
        {
            return _repository.ReadAll();
        }

        public WorkDay GetById(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var workDay = _repository.ReadById(id.Value);

            return workDay;
        }

        public WorkDay GetWorkDayDetails(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var workDay = _repository.ReadById(id.Value);
            return workDay;
        }

        public WorkDay Update(int id, WorkDay workDay)
        {
            try
            {
                _repository.Update(workDay);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_repository.IsExists(workDay.Id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
            return workDay;
        }
    }
}
