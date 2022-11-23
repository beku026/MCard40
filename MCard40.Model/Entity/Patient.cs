using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCard40.Model.Enums;
using MCard40.Model.Identity;

namespace MCard40.Model.Entity;
public class Patient
{
    /// Id
    public int Id { get; set; }

    /// ФИО 
    public string FullName { get; set; }

    /// День рождения
    public DateTime Age { get; set; }

    /// Пол 
    public Sex Sex { get; set; }

    /// ИНН 
    public short ITN { get; set; }

    /// Место жительства
    public string Address { get; set; }

    ///Группы крови
    public BloodGroup BloodGroup { get; set; }

    ///Инвалидность
    public Disability? Disability { get; set; }

    public virtual List<CardPage> CardPages { get; set; }
    public virtual User User { get; set; }
}
