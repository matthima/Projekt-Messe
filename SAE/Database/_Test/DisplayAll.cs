namespace Database._Test
{
    internal class DisplayAll
    {
        public static void Display(BaseContext db)
        {
            DisplayKunde(db);
            DisplayFirma(db);
            DisplayProduktgruppe(db);
            DisplayProduktgruppeKunde(db);
            DisplayUsers(db);
        }

        private static void DisplayKunde(BaseContext db)
        {
            Console.WriteLine("Displaying Kunden");
            foreach (Kunde kunde in db.Kunden)
            {
                Console.WriteLine($"Kunde\n\tID: {kunde.KundeId}\n\tVorname: {kunde.Vorname}\n\tNachname: {kunde.Nachname}\n\tPLZ: {kunde.PLZ}\n\tOrt: {kunde.Ort}\n\tStrasse: {kunde.Strasse}\n\tHausnummer: {kunde.Hausnummer}\n\tFirmenvertreter: {kunde.Firmenvertreter}\n\tFirmaId: {kunde.FirmaId}");
            }
            Console.WriteLine();
        }

        private static void DisplayProduktgruppe(BaseContext db)
        {
            Console.WriteLine("Displaying Produktgruppen");
            foreach (Produktgruppe p in db.Produktgruppe)
            {
                Console.WriteLine($"Produktgruppe\n\tID: {p.ProduktgruppeId}\n\tName: {p.Name}");
            }
            Console.WriteLine();
        }

        private static void DisplayFirma(BaseContext db)
        {
            Console.WriteLine("Displaying Firma");
            foreach (Firma f in db.Firmen)
            {
                Console.WriteLine($"Firma\n\tID: {f.FirmaId}\n\tName: {f.Name}");
            }
            Console.WriteLine();
        }

        private static void DisplayProduktgruppeKunde(BaseContext db)
        {
            Console.WriteLine("Displaying ProduktgruppeKunde");
            foreach (ProduktgruppeKunde p in db.ProduktgruppeKunden)
            {
                Console.WriteLine($"ProduktgruppeKunde\n\tID: {p.ProduktgruppeKundeId}\n\tKundeID: {p.KundeId}\n\tProduktgruppeID: {p.ProduktgruppeId}");
            }
            Console.WriteLine();
        }

        private static void DisplayUsers(BaseContext db)
        {
            Console.WriteLine("Displaying Users");
            foreach (User p in db.Users)
            {
                Console.WriteLine($"User\n\tID: {p.UserId}\n\tName: {p.Name}\n\tPassword: {p.Passwort}");
            }
            Console.WriteLine();
        }
    }
}
