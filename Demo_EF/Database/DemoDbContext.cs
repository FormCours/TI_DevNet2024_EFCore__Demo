using Demo_EF.Database.Configurations;
using Demo_EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using static Demo_EF.Models.Car;

namespace Demo_EF.Database
{
    public class DemoDbContext : DbContext
    {
        #region Entités de la DB
        public DbSet<Car> Car { get; set; }
        public DbSet<Brand> Brand { get; set; }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Définition de la connection string
            //  -> Setup pour un utilisation simple via l'opérateur "new"
            //  https://learn.microsoft.com/en-us/ef/core/dbcontext-configuration/
            optionsBuilder.UseSqlServer("Server=localhost;Database=Demo_EFCore;Trusted_Connection=True;Trust Server Certificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Définition de la configuration via la Fluent-API
            modelBuilder.ApplyConfiguration(new CarConfig());
            modelBuilder.ApplyConfiguration(new BrandConfig());

            // Initial Data
            modelBuilder.Entity<Car>()
                        .HasData(
                            new
                            {
                                Id = 1,
                                Model = "Samara",
                                BrandId = 1,
                                Price = 199.99m,
                                RegistrationDate = new DateTime(1987, 11, 2),
                                State = StateEnum.OCCASION
                            },
                            new
                            {
                                Id = 2,
                                Model = "R8 Spyder",
                                BrandId = 2,
                                Price = 1_930.5m,
                                State = StateEnum.FOR_PARTS
                            }
                        );

            modelBuilder.Entity<Brand>()
                        .HasData(
                            new Brand { Id = 1, Name = "Lada" },
                            new Brand { Id = 2, Name = "Audi" }
                        );

            modelBuilder.Entity<CarOption>()
                        .HasData(
                            new CarOption { Id = 1, Name = "Option 1" },
                            new CarOption { Id = 2, Name = "Option 2" },
                            new CarOption { Id = 3, Name = "Option 3" }
                        );

            modelBuilder.Entity("Car__Car_Option")
                        .HasData(
                            new { CarId = 1, OptionId = 1 },
                            new { CarId = 1, OptionId = 2 },
                            new { CarId = 2, OptionId = 1 },
                            new { CarId = 2, OptionId = 3 }
                        );
        }
    }
}
