using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebCooking.Models;

namespace WebCooking.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("user_id")
            .HasColumnType("BIGINT")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Name)
            .HasColumnName("user_name")
            .HasColumnType("varchar(100)")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Email)
            .HasColumnName("user_email")
            .HasColumnType("varchar(255)")
            .HasMaxLength(255)
            .IsRequired();
    }
}