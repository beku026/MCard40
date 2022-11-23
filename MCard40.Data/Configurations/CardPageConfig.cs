using MCard40.Model.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MCard40.Data.Configurations;
public class CardPageConfig : IEntityTypeConfiguration<CardPage>
{
    public void Configure(EntityTypeBuilder<CardPage> builder)
    {
        builder.HasKey(i => i.Id);

        builder.Property(i => i.Id)
            .HasColumnType("int")
            .IsRequired();

        builder.Property(i => i.Disease)
           .HasColumnType("nvarchar(150)")
           .IsRequired();

        builder.Property(i => i.DiseaseInfo)
           .HasColumnType("nvarchar(800)")
           .IsRequired();

        builder.Property(i => i.Treatment)
           .HasColumnType("nvarchar(800)")
           .IsRequired();
    }
}