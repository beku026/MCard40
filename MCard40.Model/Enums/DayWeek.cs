using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MCard40.Model.Enums;

/// <summary>
/// День недели
/// </summary>
public enum DayWeek
{
    [Display(Name = "Понедельник")]
    Monday = 0,

    [Display(Name = "Вторник")]
    Tuesday = 1,

    [Display(Name = "Среда")]
    Wednesday = 2,

    [Display(Name = "Четверг")]
    Thursday = 3,

    [Display(Name = "Пятница")]
    Friday = 4,

    [Display(Name = "Суббота")]
    Saturday = 5,

    [Display(Name = "Воскресенье")]
    Sunday = 6,
}
