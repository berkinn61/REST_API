namespace _01_MyFirstWebApplication
{
    public class Klassenraum
    {
        public string Name { get; set; }
        public float RaumInQm { get; set; }
        public int Plaetze { get; set; }
        public bool HasCynap { get; set; }
        public List<Schueler> SchuelerImRaum = new List<Schueler>();

        public Klassenraum(string name, float raumInQm, int plaetze, bool hasCynap)
        {
            Name = name;
            RaumInQm = raumInQm;
            Plaetze = plaetze;
            HasCynap = hasCynap;
        }
    }
}
