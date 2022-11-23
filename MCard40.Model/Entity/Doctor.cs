using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCard40.Model.Identity;

namespace MCard40.Model.Entity;
public class Doctor
{
    /// Id
    public int Id { get; set; }

    /// Должность
    public string Post { get; set; }

    /// Опыт работы
    public DateTime Experience { get; set; }

    /// Адрес работы
    public string Address_job { get; set; }

    /// Степень
    public string Degree { get; set; }

    public virtual List<CardPage> CardPages { get; set; }
    public virtual List<Week> Weeks { get; set; }
    public virtual User User { get; set; }
}
