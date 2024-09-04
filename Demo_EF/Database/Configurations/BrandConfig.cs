using Demo_EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demo_EF.Database.Configurations
{
    public class BrandConfig : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            // Tables
            builder.ToTable("Brand");

            // Colonnes
            builder.Property(b => b.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(b => b.Name)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(b => b.Country)
                   .HasMaxLength(50);

            // Contraintes
            builder.HasKey(b => b.Id)
                   .IsClustered()
                   .HasName("PK_Brand");

            builder.HasIndex(b => new { b.Name, b.Country })
                   .IsUnique();
        }
    }
}
