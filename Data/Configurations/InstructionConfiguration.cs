using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebCooking.Models;

namespace WebCooking.Data.Configurations;

public class InstructionConfiguration : IEntityTypeConfiguration<Instruction>
{
    public void Configure(EntityTypeBuilder<Instruction> builder)
    {
        builder.ToTable("Instructions");
        
        builder.HasKey(i => i.Id);
        
        builder.Property(i => i.Id)
            .HasColumnName("instruction_id")
            .HasColumnType("BIGINT")
            .ValueGeneratedOnAdd();
        
        builder.Property(i=>i.Text)
            .HasColumnName("instruction_text")
            .HasColumnType("TEXT")
            .IsRequired();
        
        builder.Property(i=>i.Order)
            .HasColumnName("instruction_order")
            .HasColumnType("INT")
            .IsRequired();
        
        builder.Property(i=>i.RecipeId)
            .HasColumnName("recipe_id")
            .HasColumnType("BIGINT")
            .IsRequired();
    }
}