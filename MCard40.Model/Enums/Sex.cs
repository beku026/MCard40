using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MCard40.Model.Enums;

/// <summary>
/// Пол пользователя
/// </summary>
public enum Sex
{
    [Display(Name = "Мужчина")]
    Man = 0,

    [Display(Name = "Женщина")]
    Woman = 1,
}

