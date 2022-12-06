using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCard40.Model.Enums;
using MCard40.Model.Interfaces;

namespace MCard40.Model.Entity;
public class Week : IEntity<int>
{
    /// Id
    public int Id { get; set; }

    /// Врач
    public int DoctorId { get; set; }

    /// Наименование дня недели
    public DayWeek DayWeeks { get; set; }
    public virtual Doctor Doctor { get; set; }
    public virtual List<WorkDay> WorkDays { get; set; }
}
