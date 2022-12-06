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
	public class ScheduleSevice : IScheduleService
	{
		private readonly IRepository<Week, int> _weekRepository;
		private readonly IRepository<WorkDay, int> _workDayRepository;

		public ScheduleSevice(IRepository<Week, int> weekRepository,
			IRepository<WorkDay, int> workDayRepository)
		{
			_weekRepository= weekRepository;
			_workDayRepository= workDayRepository;
		}

		public void Add(Week week, WorkDay workDay)
		{
			_weekRepository.Create(week);
			_workDayRepository.Create(workDay);
		}
	}
}
