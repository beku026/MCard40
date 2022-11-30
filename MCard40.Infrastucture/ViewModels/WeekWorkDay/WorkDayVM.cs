using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using MCard40.Model.Enums;

namespace MCard40.Infrastucture.ViewModels.WeekWorkDay;
public class WorkDayVM
{

    public int Id { get; set; }

    [Display(Name = "Начало")]
    public TimeSpan StartWork { get; set; }

    [Display(Name = "Конец")]
    public TimeSpan FinalWork { get; set; }

    [Display(Name = "Занятость")]
    public Employment Employment_type { get; set; }
}
