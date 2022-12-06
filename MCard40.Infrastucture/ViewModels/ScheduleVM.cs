using MCard40.Model.Entity;

namespace MCard40.Infrastucture.ViewModels
{
	public class ScheduleVM
	{
		public IEnumerable<Week> Weeks { get; set; }
		public IEnumerable<WorkDay> WorkDays { get; set; }
	
	}
}
