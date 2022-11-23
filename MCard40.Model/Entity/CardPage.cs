using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCard40.Model.Enums;
using MCard40.Model.Identity;

namespace MCard40.Model.Entity;
public class CardPage
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
    public int PatientId { get; set; }
    public int DoctorId { get; set; }
    public virtual Patient Patient { get; set; }
    public virtual Doctor Doctor { get; set; }
}
