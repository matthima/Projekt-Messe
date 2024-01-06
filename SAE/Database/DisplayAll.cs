using System.ComponentModel.DataAnnotations;

namespace Database {
    internal class DisplayAll {
        public static void Display() { 
            MesseContext db = new MesseContext();
            DisplayProduktgruppeKunde(db);
        }

        private static void DisplayKunde(MesseContext db) {
            Console.WriteLine("Displaying Kunden");
            foreach (Kunde kunde in db.Kunden) {
                Console.WriteLine($"Kunde\n\tID: {kunde.KundeId}\n\tVorname: {kunde.Vorname}\n\tNachname: {kunde.Nachname}\n\tPLZ: {kunde.PLZ}\n\tOrt: {kunde.Ort}\n\tStrasse: {kunde.Strasse}\n\tHausnummer: {kunde.Hausnummer}\n\tFirmenvertreter: {kunde.Firmenvertreter}\n\tFirmaId: {kunde.FirmaId}");
            }
        }

        private static void DisplayProduktgruppe(MesseContext db) {
            Console.WriteLine("Disaplying Produktgruppen");
            foreach (Produktgruppe p in db.Produktgruppe) {
                Console.WriteLine($"Produktgruppe\n\tID: {p.ProduktgruppeId}\n\tName: {p.Name}");
            }
        }

        private static void DisplayFirma(MesseContext db) {
            Console.WriteLine("Displaying Firma");
            foreach (Firma f in db.Firmen) {
                Console.WriteLine($"Firma\n\tID: {f.FirmaId}\n\tName: {f.Name}");
            }
        }

        private static void DisplayProduktgruppeKunde(MesseContext db) {
            Console.WriteLine("Displaying ProduktgruppeKunde");
            foreach (ProduktgruppeKunde p in db.ProduktgruppeKunden) {
                Console.WriteLine($"ProduktgruppeKunde\n\tID: {p.ProduktgruppeKundeId}\n\tKundeID: {p.KundeId}\n\tProduktgruppeID: {p.ProduktgruppeId}");
            }
        }
    }
}
