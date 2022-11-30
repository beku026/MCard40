using MCard40.Model.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MCard40.Data.Configurations;
public class PatientConfig : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.HasKey(i => i.Id);

        builder.Property(i => i.Id)
            .HasColumnType("int")
            .IsRequired();

        builder.Property(i => i.FullName)
            .HasColumnType("nvarchar(120)")
            .IsRequired();

        builder.Property(i => i.Age)
            .HasColumnType("date")
            .IsRequired();

        builder.Property(i => i.Sex)
            .HasColumnType("nvarchar(10)")
            .IsRequired();

        builder.HasIndex(u => u.ITN).IsUnique();

        builder.Property(i => i.ITN)
            .HasColumnType("nvarchar(14)")
            .HasMaxLength(14)
            .IsRequired();

        builder.Property(i => i.Address)
            .HasColumnType("nvarchar(250)");

    }
}
