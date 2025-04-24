using Microsoft.EntityFrameworkCore;
using SmallApplicationEF;
using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        using (var context = new DBContext())
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var city = new City
            {
                Name = "Dornbirn",
                People = new List<Person>()
            };

            context.Cities.Add(city);
            context.SaveChanges();

            Console.WriteLine("Möchten Sie eine neue Person hinzufügen? (ja/nein): ");
            string userInput = Console.ReadLine()?.ToLower();

            while (userInput == "ja")
            {
                Console.WriteLine("Geben Sie den Vornamen der Person ein: ");
                string firstName = Console.ReadLine();

                Console.WriteLine("Geben Sie den Nachnamen der Person ein: ");
                string lastName = Console.ReadLine();

                Console.WriteLine("Geben Sie das Alter der Person ein: ");
                int age;
                while (!int.TryParse(Console.ReadLine(), out age) || age <= 0)
                {
                    Console.WriteLine("Bitte geben Sie ein gültiges Alter ein: ");
                }

                var newPerson = new Person
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Age = age,
                    City = city
                };

                city.People.Add(newPerson);
                context.SaveChanges();

                Console.WriteLine("Möchten Sie eine weitere Person hinzufügen? (ja/nein): ");
                userInput = Console.ReadLine()?.ToLower();
            }

            var cities = context.Cities.Include(c => c.People).ToList();

            foreach (var c in cities)
            {
                Console.WriteLine($"Stadt: {c.Name}");
                foreach (var p in c.People)
                {
                    Console.WriteLine($"- {p.FirstName} {p.LastName}, Alter: {p.Age}");
                }
            }
        }
    }
}
