using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCard40.Model.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MCard40.Data.Configurations;
public class WeekConfig : IEntityTypeConfiguration<Week>
{
    public void Configure(EntityTypeBuilder<Week> builder)
    {
        builder.HasKey(i => i.Id);

        builder.HasOne(u => u.Doctor)
           .WithMany(c => c.Weeks)
           .HasForeignKey(u => u.DoctorId)
           .OnDelete(DeleteBehavior.Restrict);

        builder.Property(i => i.Id)
            .HasColumnType("int")
            .IsRequired();

        builder.Property(i => i.DoctorId)
            .HasColumnType("int")
            .IsRequired();

    }
}
