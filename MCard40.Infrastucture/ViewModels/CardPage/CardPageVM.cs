using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using MCard40.Model.Enums;

namespace MCard40.Infrastucture.ViewModels.CardPage;
public class CardPageVM
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Обязательно укажите болезнь")]
    [Display(Name = "Болезень")]
    public string Disease { get; set; }

    [Required(ErrorMessage = "Обязательно укажите информацию о болезни")]
    [Display(Name = "Информация о болезни")]
    public string DiseaseInfo { get; set; }

    [Required(ErrorMessage = "Обязательно укажите лечение")]
    [Display(Name = "Лечение")]
    public string Treatment { get; set; }

    [Required(ErrorMessage = "Обязательно поставьте оценку")]
    [Display(Name = "Оценка врача")]
    public Assessment Assessment { get; set; }
}
