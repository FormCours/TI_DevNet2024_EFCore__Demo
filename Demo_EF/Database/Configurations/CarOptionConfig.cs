using Demo_EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demo_EF.Database.Configurations
{
    public class CarOptionConfig : IEntityTypeConfiguration<CarOption>
    {
        public void Configure(EntityTypeBuilder<CarOption> builder)
        {
            // Tables
            builder.ToTable("Car_Option");

            // Colonnes
            builder.Property(c => c.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(c => c.Name)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(c => c.Description)
                   .HasColumnType("nvarchar(max)");

            // Contraintes
            builder.HasKey(c => c.Id)
                   .HasName("PK_Car_Option");
        }
    }
}
