using Microsoft.EntityFrameworkCore;
using SmallApplicationEF;
using System;
using System.Linq;
using System.Collections.Generic;

namespace SmallApplicationEF    
{
    class Program
    {
        public static void Main(string[] args)
        {
            using (var context = new DBContext())
            {
                context.Database.Migrate();

                var city = context.Cities.Include(c => c.Persons).FirstOrDefault();
                if (city == null)
                {
                    Console.WriteLine("Neue Stadt anlegen:");
                    Console.Write("Name der Stadt: ");
                    string cityName = Console.ReadLine() ?? "Unbekannt";
                    city = new City { Name = cityName };
                    context.Cities.Add(city);
                    context.SaveChanges();
                }

                Console.WriteLine($"Gespeicherte Personen in {city.Name}:");
                if (city.Persons.Any())
                {
                    foreach (var person in city.Persons)
                    {
                        Console.WriteLine($"  - ID: {person.Id}, Name: {person.Name}, PLZ: {person.PLZ}");
                    }
                }
                else
                {
                    Console.WriteLine("  - Keine Personen vorhanden.");
                }

                Console.WriteLine("\nNeue Person hinzufügen (Name eingeben, 'exit' zum Beenden):");
                string? name = Console.ReadLine();

                while (name?.ToLower() != "exit")
                {
                    if (string.IsNullOrWhiteSpace(name))
                    {
                        Console.WriteLine("Fehler: Name darf nicht leer sein.");
                        name = Console.ReadLine();
                        continue;
                    }

                    string? plz = null;
                    bool validPlz = false;
                    while (!validPlz)
                    {
                        Console.WriteLine("Postleitzahl eingeben:");
                        plz = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(plz))
                        {
                            Console.WriteLine("Fehler: PLZ darf nicht leer sein.");
                        }
                        else
                        {
                            validPlz = true;
                        }
                    }

                    var newPerson = new Person
                    {
                        Name = name,
                        PLZ = plz,
                        City = city
                    };

                    city.Persons.Add(newPerson);
                    context.SaveChanges();

                    Console.WriteLine("Person gespeichert! Nächste Person (oder 'exit'):");
                    name = Console.ReadLine();
                }
            }

            Console.WriteLine("Programm beendet!");
        }
    }
}
