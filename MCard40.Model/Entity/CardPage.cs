using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MCard40.Model.Enums;
using MCard40.Model.Identity;
using MCard40.Model.Interfaces;

namespace MCard40.Model.Entity;
public class CardPage : IEntity<int>
{
    /// ID
    public int Id { get; set; }

    /// Болезнь
    public string Disease { get; set; }

    /// Информация о болезни пациента
    public string DiseaseInfo { get; set; }

    /// Лечение
    public string Treatment { get; set; }

    /// Важность записи
    public Assessment Assessment { get; set; }

    /// Дата создания записи 
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode=true)]
    [DataType(DataType.Date)]
    public DateTime? DateСreation { get; set; }
    public int PatientId { get; set; }
    public int DoctorId { get; set; }
    public virtual Patient Patient { get; set; }
    public virtual Doctor Doctor { get; set; }
}
