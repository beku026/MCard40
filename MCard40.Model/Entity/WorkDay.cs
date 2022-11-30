using MCard40.Model.Enums;
using MCard40.Model.Interfaces;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MCard40.Model.Entity;
public class WorkDay : IEntity<int>
{
    /// ID
    public int Id { get; set; }

    /// Начало
    public TimeSpan StartWork { get; set; }

    /// Конец
    public TimeSpan FinalWork { get; set; }

    /// Тип занятости
    public Employment Employment_type { get; set; }
    public int WeekId { get; set; }
    public virtual Week Week { get; set; }
}
