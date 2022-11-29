using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
    [Required]
    public int Id { get; set; }
    /// <summary>
    /// Фио
    /// </summary>
    [Required]
    [Display(Name = "ФИО врача")]
    public string FullName { get; set; }

    /// День рождения
    [Display(Name = "День рождения")]
    public DateTime Age { get; set; }

    /// Пол 
    [Display(Name = "Пол")]
    public Sex Sex { get; set; }

    /// <summary>
    /// ITN
    /// </summary>
    [MaxLength(14)]
    [MinLength(14)]
<<<<<<< HEAD
    [Display(Name = "ИНН")]
=======
    //[StringLength(14, MinimumLength = 14, ErrorMessage = "Длина меньше 14")]
>>>>>>> 7c5bee4ba5ee5b67536b79df91d5dc30dadbb269
    public string ITN { get; set; }

    /// Адрес дома
    [Display(Name = "Место жительства")]
    public string Address_home { get; set; }

    /// Должность
    [Display(Name = "Должность")]
    public string Post { get; set; }

    /// Опыт работы
    [Display(Name = "Опыт работы")]
    public DateTime Experience { get; set; }

    /// Адрес работы
    [Display(Name = "Место работы")]
    public string Address_job { get; set; }

    /// Степень
    [Display(Name = "Степень")]
    public string Degree { get; set; }

    public virtual List<CardPage> CardPages { get; set; }
    public virtual List<Week> Weeks { get; set; }
    public virtual User User { get; set; }
}
