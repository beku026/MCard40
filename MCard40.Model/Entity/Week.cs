using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCard40.Model.Enums;

namespace MCard40.Model.Entity;
public class Week : Entity<int>
{
    /// Id
    public int Id { get; set; }

    /// Расписание дня
    //public int DayId { get; set; }

    /// Врач
    public int DoctorId { get; set; }

    /// Наименование дня недели
    public DayWeek DayWeeks { get; set; }
    public virtual Doctor Doctor { get; set; }
    public virtual List<WorkDay> WorkDays { get; set; }
}
