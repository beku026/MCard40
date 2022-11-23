using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MCard40.Model.Enums;

/// <summary>
/// Тип занятости
/// </summary>
public enum Employment
{
    [Display(Name = "Прием пациентов")]
    Reception = 0,

    [Display(Name = "Обед")]
    Dinner = 1,

    [Display(Name = "Семинар")]
    Seminar = 2,

    [Display(Name = "Конференция")]
    Сonference = 3,

    [Display(Name = "Дезинфекция рабочего места")]
    WorkplaceDisinfection = 4,
}