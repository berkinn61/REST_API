using NUnit.Framework;
using _01_MyFirstWebApplication;
using System;
using System.Collections.Generic;

namespace SchoolTest
{
    [TestFixture]
    public class SchuleTests
    {
        private Schule schule;
        [SetUp]
        public void Initialisierung()
        {
            schule = new Schule();
        }

        [Test]
        public void Person_Geschlecht_UngültigerWert_SetztUnbekannt()
        {
            var person = new Person(new DateTime(2002, 1, 1), "invalid");
            Assert.AreEqual("unbekannt", person.Geschlecht);
        }

        [Test]
        public void Person_Geschlecht_GültigerWert_SetztKorrekt()
        {
            var person = new Person(new DateTime(2002, 1, 1), "männlich");
            Assert.AreEqual("männlich", person.Geschlecht);
        }

        [Test]
        public void Schueler_Alter_Berechnung_Korrekt()
        {
            var schueler = new Schueler("10A", new DateTime(2002, 1, 1), "männlich");
            int erwartetesAlter = DateTime.Today.Year - 2002;
            Assert.AreEqual(erwartetesAlter, schueler.Alter);
        }

        [Test]
        public void Schule_SchuelerHinzufuegen_ErhoehtAnzahl()
        {
            var schueler = new Schueler("10A", new DateTime(2002, 1, 1), "männlich");
            schule.AddSchuelerToSchule(schueler);
            Assert.AreEqual(1, schule.AnzahlSchueler);
        }

        [Test]
        public void Schule_AnzahlRaeumeMitCynap_GibtNurCynapRaeumeZurueck()
        {
            var raum1 = new Klassenraum(50, 30, true);
            var raum2 = new Klassenraum(40, 25, false);
            schule.AddKlassenraumToSchule(raum1);
            schule.AddKlassenraumToSchule(raum2);
            var cynapRaeume = schule.AnzahlRauemeCynap();
            Assert.AreEqual(1, cynapRaeume.Count);
            Assert.IsTrue(cynapRaeume[0].HasCynap);
        }

        [Test]
        public void Schule_DurchschnittsalterSchueler_KorrekteBerechnung()
        {
            schule.AddSchuelerToSchule(new Schueler("10A", new DateTime(2002, 1, 1), "männlich"));
            schule.AddSchuelerToSchule(new Schueler("10B", new DateTime(2004, 1, 1), "weiblich"));
            float erwarteterDurchschnitt = (float)((DateTime.Today.Year - 2002) + (DateTime.Today.Year - 2004)) / 2;
            Assert.AreEqual(erwarteterDurchschnitt, schule.DurchschnittsalterSchueler());
        }

        [Test]
        public void Schule_FrauenanteilInProzent_KorrekteBerechnung()
        {
            var schuelerListe = new List<Schueler>
            {
                new Schueler("10A", new DateTime(2002, 1, 1), "männlich"),
                new Schueler("10A", new DateTime(2002, 1, 1), "weiblich"),
                new Schueler("10A", new DateTime(2002, 1, 1), "weiblich")
            };
            double ergebnis = schule.BerechneFrauenanteilInProzent(schuelerListe, "10A");
            Assert.AreEqual(66.66666666666666, ergebnis, 0.01);
        }

        [Test]
        public void Schule_KannKlasseUnterrichten_GenugPlatz_GibtTrueZurueck()
        {
            schule.AddSchuelerToSchule(new Schueler("10A", new DateTime(2002, 1, 1), "männlich"));
            schule.AddSchuelerToSchule(new Schueler("10A", new DateTime(2002, 1, 1), "weiblich"));
            schule.AddKlassenraumToSchule(new Klassenraum(50, 5, true));
            bool ergebnis = schule.KannKlasseUnterrichten("10A", "50");
            Assert.IsTrue(ergebnis);
        }

        [Test]
        public void Schule_KannKlasseUnterrichten_NichtGenugPlatz_GibtFalseZurueck()
        {
            schule.AddSchuelerToSchule(new Schueler("10A", new DateTime(2002, 1, 1), "männlich"));
            schule.AddSchuelerToSchule(new Schueler("10A", new DateTime(2002, 1, 1), "weiblich"));
            schule.AddKlassenraumToSchule(new Klassenraum(50, 1, true));
            bool ergebnis = schule.KannKlasseUnterrichten("10A", "50");
            Assert.IsFalse(ergebnis);
        }

        [Test]
        public void Schule_AnzahlSchuelerNachGeschlecht_KorrekteZaehlung()
        {
            schule.AddSchuelerToSchule(new Schueler("10A", new DateTime(2002, 1, 1), "männlich"));
            schule.AddSchuelerToSchule(new Schueler("10B", new DateTime(2002, 1, 1), "weiblich"));
            string ergebnis = schule.AnzahlSchuelerGeschlecht;
            Assert.AreEqual("männliche: 1 / weibliche: 1", ergebnis);
        }
    }
}