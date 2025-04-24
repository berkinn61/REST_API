using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_MyFirstWebApplication
{
    public class Schule
    {
        public List<Schueler> SchuelerList = new List<Schueler>();
        public List<Klassenraum> KlassenraumList = new List<Klassenraum>();

        public void AddSchuelerToSchule(Schueler schueler)
        {
            SchuelerList.Add(schueler);
        }

        public void AddKlassenraumToSchule(Klassenraum klassenraum)
        {
            KlassenraumList.Add(klassenraum);
        }

        public int AnzahlSchueler => SchuelerList.Count;
        public int AnzahlKlassenRaum => KlassenraumList.Count;

        public List<Klassenraum> AnzahlRauemeCynap()
        {
            return KlassenraumList.Where(kr => kr.HasCynap).ToList();
        }

        public int AnzahlKlassen(Schueler schueler)
        {
            return schueler.klassen.Count;
        }

        public float DurchschnittsalterSchueler()
        {
            if (AnzahlSchueler == 0) return 0;
            return (float)SchuelerList.Sum(s => s.Alter) / AnzahlSchueler;
        }

        public double BerechneFrauenanteilInProzent(List<Schueler> schuelerListe, string klasse)
        {
            var schuelerInKlasse = schuelerListe.Where(s => s.Klasse == klasse).ToList();
            if (schuelerInKlasse.Count == 0) return 0;

            int anzahlFrauen = schuelerInKlasse.Count(s => s.Geschlecht == "weiblich");
            return (double)anzahlFrauen / schuelerInKlasse.Count * 100;
        }

        public bool KannKlasseUnterrichten(string klasse, string raumName)
        {
            int schuelerInKlasse = SchuelerList.Count(s => s.Klasse == klasse);
            Klassenraum raum = KlassenraumList.FirstOrDefault(kr => kr.Name == raumName);

            return raum != null && raum.Plaetze >= schuelerInKlasse;
        }

        public string AnzahlSchuelerGeschlecht
        {
            get
            {
                int männlicheSchueler = SchuelerList.Count(s => s.Geschlecht == "männlich");
                int weiblicheSchueler = SchuelerList.Count(s => s.Geschlecht == "weiblich");
                return $"männliche: {männlicheSchueler} / weibliche: {weiblicheSchueler}";
            }
        }
    }
}
