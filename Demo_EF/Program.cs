using Demo_EF.Database;
using Demo_EF.Models;
using Microsoft.EntityFrameworkCore;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;
Console.WriteLine("Utilisation de EFCore");

using(DemoDbContext db = new DemoDbContext())
{
    Console.WriteLine("Ajout d'une voiture...");
    Brand? mazda = db.Brand.SingleOrDefault(b => b.Name == "Mazda");
    if (mazda is null)
    {
        mazda = new Brand { Name = "Mazda", Country = "Japon" };
        db.Brand.Add(mazda);
    }


    db.Car.Add(new Car
    {
        Model = "MX5",
        Brand = mazda,
        Price = 10.00m,
        RegistrationDate = DateTime.Today,
        State = Car.StateEnum.NEW
    });

    db.Car.Add(new Car
    {
        Model = "Error",
        Brand = db.Brand.First(b => b.Name == "Audi" && b.Country == null),
        Price = 1_000_000.10m,
        RegistrationDate = new DateTime(2004, 2, 29),
        State = Car.StateEnum.OCCASION
    });
    db.SaveChanges();

    Console.ReadLine();
    /***********************************************************/
    Console.WriteLine("Liste des voitures non neuve");

    var result = db.Car
                   .Where(c => c.Price > 100 
                        && c.State != Car.StateEnum.NEW);

    foreach (Car c in result)
    {
        Console.WriteLine($" - {c.Id} {c.Model} {c.Price}€ {c.State}");
    }

    Console.ReadLine();
    /***********************************************************/
    Console.WriteLine("Mise à jour de la voiture en erreur");

    Car targetUpdate = db.Car.Single(c => c.Model == "Error");
    targetUpdate.Model = "Not a Error";
    targetUpdate.Price = 1_000.99m;
    db.Car.Update(targetUpdate);
    db.SaveChanges();

    Console.ReadLine();
    /***********************************************************/
    Console.WriteLine("Liste de toutes les voitures avec la marque");

    IEnumerable<Car> result2 = db.Car.Include(c => c.Brand);

    foreach (Car c in result2)
    {
        Console.WriteLine($" - {c.Id} {c.Model} {c.Price}€ {c.Brand.Name}");
    }

    Console.ReadLine();
    /***********************************************************/
    Console.WriteLine("Supression d'une voiture");

    var targetDelete = db.Car.First(c => c.Model == "MX5");
    db.Car.Remove(targetDelete);
    db.SaveChanges();
}