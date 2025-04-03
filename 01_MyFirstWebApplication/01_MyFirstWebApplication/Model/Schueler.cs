using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_MyFirstWebApplication
{
    public class Schueler : Person
    {
        public string Klasse { get; set; }
        public List<string> klassen = new List<string>();

        public void AddKlasse(string klasse)
        {
            if (!klassen.Contains(klasse))
            {
                klassen.Add(klasse);
            }
        }

        public int Alter
        {
            get
            {
                var today = DateTime.Today;
                int alter = today.Year - Geburtstag.Year;
                if (today < Geburtstag.AddYears(alter)) alter--; // Korrektur für Geburtsdatum
                return alter;
            }
        }

        public void ZähleSchülerProKlasse(List<Schueler> schuelerListe)
        {
            var gruppiert = schuelerListe.GroupBy(s => s.Klasse);
            foreach (var gruppe in gruppiert)
            {
                Console.WriteLine($"Klasse {gruppe.Key}: {gruppe.Count()} Schüler");
            }
        }

        public Schueler(string klasse, DateTime geburtstag, string geschlecht) : base(geburtstag, geschlecht)
        {
            Klasse = klasse;
            AddKlasse(klasse);
        }
    }
}
