using SmallApplicationEF;
using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        using (var context = new DBContext())
        {
            context.Database.EnsureCreated();

            var person = new Person
            {
                FirstName = "Berkin",
                LastName = "Filiz",
                Age = 17


            };

            var person2 = new Person
            {
                FirstName = "Hans",
                LastName = "Müller",
                Age = 20
            };

            context.People.Add(person);
            context.People.Add(person2);

            context.SaveChanges();

            var people = context.People.ToList();

            Console.WriteLine("Alle Personen in der Datenbank:");
            foreach (var p in people)
            {
                Console.WriteLine($"Id: {p.Id}, Name: {p.FirstName} {p.LastName}, Age: {p.Age}");
            }
        }
    }
}
