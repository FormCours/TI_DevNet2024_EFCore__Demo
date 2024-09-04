using Azure;
using Demo_EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Demo_EF.Database.Configurations
{
    public class CarConfig : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            // Tables
            builder.ToTable("Vrouvoum");

            // Colonnes
            builder.Property(c => c.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(c => c.Model)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(c => c.Price)
                   .HasPrecision(9, 2)
                   .IsRequired();

            builder.Property(c => c.RegistrationDate)
                   .HasColumnType("date");

            builder.Property(c => c.State)
                   .IsRequired();

            // Contraintes
            builder.HasKey(c => c.Id)
                   .HasName("PK_Car");

            builder.ToTable(t => t.HasCheckConstraint("CK_Car__Price", "[Price] >= 0"));

            // Relations
            builder.HasOne(c => c.Brand)
                   .WithMany(brand => brand.Cars)
                   .OnDelete(DeleteBehavior.NoAction)
                   .IsRequired();

            builder.HasMany(c => c.Options)
                   .WithMany(co => co.Cars)
                   .UsingEntity(
                        "Car__Car_Option",
                        l => l.HasOne(typeof(CarOption)).WithMany().HasForeignKey("OptionId").HasPrincipalKey(nameof(CarOption.Id)),
                        r => r.HasOne(typeof(Car)).WithMany().HasForeignKey("CarId").HasPrincipalKey(nameof(Car.Id)),
                        j => j.HasKey("CarId", "OptionId")
                   );
        }
    }
}