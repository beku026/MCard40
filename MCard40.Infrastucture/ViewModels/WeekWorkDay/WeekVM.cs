using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using MCard40.Model.Enums;

namespace MCard40.Infrastucture.ViewModels.WeekWorkDay;
public class WeekVM
{
    public int Id { get; set; }

    [Display(Name = "День недели")]
    public DayWeek DayWeeks { get; set; }
}
