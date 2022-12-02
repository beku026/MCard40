using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MCard40.Model.Enums;

/// <summary>
/// Инвалидность
/// </summary>
public enum Disability
{
    [Display(Name = "Отсутствует")]
    NoDegreeDisability = 0,

    [Display(Name = "I группа")]
    FirstDegreeDisability = 1,

    [Display(Name = "II группа")]
    SecondDegreeDisability = 2,

    [Display(Name = "III группа")]
    ThirdDegreeDisability = 3,
}