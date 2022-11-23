using MCard40.Model.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MCard40.Data.Configurations;
public class DoctorConfig : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {

        builder.HasKey(i => i.Id);

        builder.Property(i => i.Id)
            .HasColumnType("int")
            .IsRequired();

        builder.Property(i => i.Post)
            .HasColumnType("nvarchar(50)")
            .IsRequired();

        builder.Property(i => i.Experience)
            .HasColumnType("date")
            .IsRequired();

        builder.Property(i => i.Address_job)
            .HasColumnType("nvarchar(250)")
            .IsRequired();

        builder.Property(i => i.Degree)
            .HasColumnType("nvarchar(30)")
            .IsRequired();

    }
}
