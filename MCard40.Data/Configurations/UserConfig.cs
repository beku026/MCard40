using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MCard40.Model.Identity;

namespace MCard40.Data.Configurations;
public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(i => i.Id);

        builder.Property(i => i.Id)
            .HasColumnType("nvarchar(250)")
            .IsRequired();

        builder.Property(i => i.Nickname)
                .HasColumnType("nvarchar(120)")
                .IsRequired();
    }
}
