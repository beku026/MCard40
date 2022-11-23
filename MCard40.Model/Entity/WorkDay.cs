using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCard40.Model.Enums;

namespace MCard40.Model.Entity;
public class WorkDay
{
    /// ID
    public int Id { get; set; }

    /// Начало
    public DateTime StartWork { get; set; }

    /// Конец
    public DateTime FinalWork { get; set; }

    /// Тип занятости
    public Employment Employment_type { get; set; }
    public int WeekId { get; set; }
    public virtual Week Week { get; set; }
}
