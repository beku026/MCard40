using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCard40.Model.Enums;

namespace MCard40.Infrastucture.ViewModels.Patient;
public class PatientVM
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Обязательно введите ФИО")]
    [Display(Name = "ФИО")]
    public string FullName { get; set; }

    [Required(ErrorMessage = "Обязательно укажите день рождения")]
    [Display(Name = "Дата рождения")]
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
    [Display(Name = "Адресс")]
    public string Address { get; set; }

    [Required(ErrorMessage = "Обязательно укажите группу крови")]
    [Display(Name = "Группа крови")]
    public BloodGroup BloodGroup { get; set; }

    [Display(Name = "Инвалидность")]
    public Disability? Disability { get; set; }
}
