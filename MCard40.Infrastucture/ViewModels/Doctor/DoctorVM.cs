using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCard40.Model.Enums;
using System.Xml.Linq;

namespace MCard40.Infrastucture.ViewModels.Doctor;
public class DoctorVM
{

    public int Id { get; set; }

    [Required(ErrorMessage = "Обязательно введите ФИО")]
    [Display(Name = "ФИО врача")]
    public string FullName { get; set; }

    [Required(ErrorMessage = "Обязательно укажите день рождения")]
    [Display(Name = "День рождения")]
    public DateTime Age { get; set; }

    [Required(ErrorMessage = "Обязательно укажите пол")]
    [Display(Name = "Пол")]
    public Sex Sex { get; set; }

    [MaxLength(14)]
    [MinLength(14)]
    [Required(ErrorMessage = "Обязательно укажите ИНН")]
    [Display(Name = "ИНН")]
    public string ITN { get; set; }

    [Required(ErrorMessage = "Обязательно укажите место жительства")]
    [Display(Name = "Место жительства")]
    public string Address_home { get; set; }

    [Required(ErrorMessage = "Обязательно укажите должность")]
    [Display(Name = "Должность")]
    public string Post { get; set; }

    [Required(ErrorMessage = "Обязательно укажите опыт работы")]
    [Display(Name = "Опыт работы")]
    public DateTime Experience { get; set; }

    [Required(ErrorMessage = "Обязательно укажите место работы")]
    [Display(Name = "Место работы")]
    public string Address_job { get; set; }

    [Required(ErrorMessage = "Обязательно укажите степень")]
    [Display(Name = "Степень")]
    public string Degree { get; set; }
}
