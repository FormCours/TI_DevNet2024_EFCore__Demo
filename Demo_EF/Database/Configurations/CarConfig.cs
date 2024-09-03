using Demo_EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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

            // Initial Data
            builder.HasData(
                new Car
                {
                    Id = 1,
                    Model = "Samara",
                    Price = 199.99m,
                    RegistrationDate = new DateTime(1987, 11, 2),
                    State = Car.StateEnum.OCCASION
                },
                new Car
                {
                    Id = 2,
                    Model = "R8 Spyder",
                    Price = 1_930.5m,
                    RegistrationDate = null,
                    State = Car.StateEnum.FOR_PARTS
                }
            );
        }
    }
}