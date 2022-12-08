using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCard40.Model.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MCard40.Data.Configurations;
public class WorkDayConfig : IEntityTypeConfiguration<WorkDay>
{
    public void Configure(EntityTypeBuilder<WorkDay> builder)
    {
        builder.HasKey(i => i.Id);

        builder.HasOne(u => u.Week)
           .WithMany(c => c.WorkDays)
           .HasForeignKey(u => u.WeekId)
           .OnDelete(DeleteBehavior.Restrict);

        builder.Property(i => i.Id)
            .HasColumnType("int")
            .IsRequired();

        builder.Property(i => i.StartWork)
            .IsRequired();

        builder.Property(i => i.FinalWork)
            .IsRequired();
    }
}
