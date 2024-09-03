using Demo_EF.Database.Configurations;
using Demo_EF.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo_EF.Database
{
    public class DemoDbContext : DbContext
    {
        #region Entités de la DB
        public DbSet<Car> Car { get; set; }
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
        }
    }
}
