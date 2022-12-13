using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCard40.Model.Enums;
using MCard40.Model.Identity;
using MCard40.Model.Interfaces;

namespace MCard40.Model.Entity;
public class Patient : IEntity<int>
{
    /// Id
    public int Id { get; set; }

    /// ФИО 
    [Required(ErrorMessage = "Обязательно введите ФИО")]
    [Display(Name = "ФИО")]
    public string FullName { get; set; }

    /// День рождения
    [Required(ErrorMessage = "Обязательно укажите день рождения")]
    [Display(Name = "Дата рождения")]
    [DataType(DataType.Date)]
    public DateTime Age { get; set; }

    /// Пол 
    [Required(ErrorMessage = "Обязательно укажите пол")]
    [Display(Name = "Пол")]
    public Sex Sex { get; set; }

    /// ИНН 
    [MaxLength(14)]
    [MinLength(14)]
    [Required(ErrorMessage = "Обязательно укажите ИНН")]
    [Display(Name = "ИНН")]
    public string ITN { get; set; }

    /// Место жительства
    [Required(ErrorMessage = "Обязательно укажите место жительства")]
    [Display(Name = "Адрес")]
    public string Address { get; set; }

    ///Группы крови
    [Required(ErrorMessage = "Обязательно укажите группу крови")]
    [Display(Name = "Группа крови")]
    public BloodGroup BloodGroup { get; set; }

    ///Инвалидность
    [Display(Name = "Инвалидность")]
    public Disability? Disability { get; set; }

    public virtual List<CardPage> CardPages { get; set; }

    public string? UserId { get; set; }
    public virtual User User { get; set; }

}
