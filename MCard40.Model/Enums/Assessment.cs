using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MCard40.Model.Enums;

/// <summary>
/// Важность записи
/// </summary>
public enum Assessment
{
    [Display(Name = "Не важно")]
    FirstPositiveGroup = 0,

    [Display(Name = "Низкая")]
    SecondPositiveGroup = 1,

    [Display(Name = "Средняя")]
    ThirdPositiveGroup = 2,

    [Display(Name = "Высокая")]
    FourthPositiveGroup = 3,

    [Display(Name = "Очень высокая")]
    FirstNegativeGroup = 4,
}
