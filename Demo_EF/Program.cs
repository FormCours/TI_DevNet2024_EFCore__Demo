using Demo_EF.Database;
using Demo_EF.Models;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;
Console.WriteLine("Utilisation de EFCore");

using(DemoDbContext db = new DemoDbContext())
{
    Console.WriteLine("Ajout d'une voiture...");

    db.Car.Add(new Car
    {
        Model = "MX5",
        Price = 10.00m,
        RegistrationDate = DateTime.Today,
        State = Car.StateEnum.NEW
    });

    db.Car.Add(new Car
    {
        Model = "Error",
        Price = 1_000_000.10m,
        RegistrationDate = new DateTime(2004, 2, 29),
        State = Car.StateEnum.OCCASION
    });
    db.SaveChanges();

    Console.ReadLine();
    /***********************************************************/
    Console.WriteLine("Liste des voitures");

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
    Console.WriteLine("Liste des voitures");

    var result2 = db.Car
                   .Where(c => c.Price > 100
                        && c.State != Car.StateEnum.NEW);

    foreach (Car c in result2)
    {
        Console.WriteLine($" - {c.Id} {c.Model} {c.Price}€ {c.State}");
    }

    Console.ReadLine();
    /***********************************************************/
    Console.WriteLine("Supression d'une voiture");

    var targetDelete = db.Car.First(c => c.Model == "MX5");
    db.Car.Remove(targetDelete);
    db.SaveChanges();
}