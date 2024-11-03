using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebCooking.Models;

namespace WebCooking.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        
        builder.HasKey(u => u.Id);
        
        builder.Property(u => u.Id)
            .HasColumnName("user_id")
            .ValueGeneratedOnAdd();
        
        builder.Property(u=>u.UserName)
            .HasColumnName("user_name")
            .HasColumnType("Varchar(255)")
            .HasMaxLength(255)
            .IsRequired();
        
        builder.HasIndex(u=>u.UserName).IsUnique();
        
        builder.Property(u=>u.FirstName)
            .HasColumnName("first_name")
            .HasColumnType("Varchar(255)")
            .HasMaxLength(255)
            .IsRequired();
        
        builder.Property(u=>u.LastName)
            .HasColumnName("last_name")
            .HasColumnType("Varchar(255)")
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(u=>u.PasswordHash)
            .HasColumnName("user_password_hash")
            .HasColumnType("Varchar(255)")
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(u => u.Email)
            .HasColumnName("user_email")
            .HasColumnType("varchar(255)")
            .HasMaxLength(255)
            .IsRequired();
        
        builder.HasIndex(u => u.Email).IsUnique();
        
        builder.Property(u=>u.EmailConfirmed)
            .HasColumnName("user_email_confirmed")
            .HasColumnType("TinyInt(1)")
            .HasDefaultValue(false)
            .IsRequired();
    }
}