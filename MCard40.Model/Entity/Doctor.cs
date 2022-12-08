using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCard40.Model.Enums;
using MCard40.Model.Identity;
using MCard40.Model.Interfaces;

namespace MCard40.Model.Entity;
public class Doctor : IEntity<int>
{
    /// <summary>
    /// ID
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Фио
    /// </summary>
    [Required(ErrorMessage = "Обязательно введите ФИО")]
    [Display(Name = "ФИО врача")]
    public string FullName { get; set; }

    /// День рождения
    [Required(ErrorMessage = "Обязательно укажите день рождения")]
    [Display(Name = "День рождения")]
    [DataType(DataType.Date)]
    public DateTime Age { get; set; }

    /// Пол 
    [Required(ErrorMessage = "Обязательно укажите пол")]
    [Display(Name = "Пол")]
    public Sex Sex { get; set; }

    /// <summary>
    /// ITN
    /// </summary>
    [MaxLength(14)]
    [MinLength(14)]
    [Required(ErrorMessage = "Обязательно укажите ИНН")]
    [Display(Name = "ИНН")]
    public string ITN { get; set; }

    /// Адрес дома
    [Required(ErrorMessage = "Обязательно укажите место жительства")]
    [Display(Name = "Место жительства")]
    public string Address_home { get; set; }

    /// Должность
    [Required(ErrorMessage = "Обязательно укажите должность")]
    [Display(Name = "Должность")]
    public string Post { get; set; }

    /// Опыт работы
    [Required(ErrorMessage = "Обязательно укажите опыт работы")]
    [Display(Name = "Опыт работы")]
    [DataType(DataType.Date)]
    public DateTime Experience { get; set; }

    /// Адрес работы
    [Required(ErrorMessage = "Обязательно укажите место работы")]
    [Display(Name = "Место работы")]
    public string Address_job { get; set; }

    /// Степень
    [Required(ErrorMessage = "Обязательно укажите степень")]
    [Display(Name = "Степень")]
    public string Degree { get; set; }

    public virtual List<CardPage> CardPages { get; set; }
    public virtual List<Week> Weeks { get; set; }
    [Required]
    public string? UserId { get; set; }
    public virtual User User { get; set; }
}
