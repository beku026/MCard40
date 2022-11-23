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
    [Display(Name = "I группа")]
    FirstDegreeDisability = 0,

    [Display(Name = "II группа")]
    SecondDegreeDisability = 1,

    [Display(Name = "III группа")]
    ThirdDegreeDisability = 2,
}