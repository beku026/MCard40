using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MCard40.Model.Enums;
/// <summary>
/// Группы крови
/// </summary>
public enum BloodGroup
{
    [Display(Name = "Первая (0) положительная  I+")]
    FirstPositiveGroup = 0,

    [Display(Name = "Вторая (А) положительная  II+")]
    SecondPositiveGroup = 1,

    [Display(Name = "Третья (В) положительная  III+")]
    ThirdPositiveGroup = 2,

    [Display(Name = "Четвертая(АВ) положительная IV+")]
    FourthPositiveGroup = 3,

    [Display(Name = "Первая (0) отрицательная  I-")]
    FirstNegativeGroup = 4,

    [Display(Name = "Вторая (А) отрицательная  II-")]
    SecondNegativeGroup = 5,

    [Display(Name = "Третья (В) отрицательная  III-")]
    ThirdNegativeGroup = 6,

    [Display(Name = "Четвертая (АВ) отрицательная  IV-")]
    FourthNegativeGroup = 7,
}
