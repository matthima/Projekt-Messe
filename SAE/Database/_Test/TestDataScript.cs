using Microsoft.EntityFrameworkCore;

namespace Database._Test {
    internal class TestDataScript {
        public static void CreateTestData(BaseContext db) {
            Console.WriteLine($"Database path: {db.DbPath}.");

            Console.WriteLine("Clearing all data");
            foreach (User user in db.Users) {
                db.Users.Remove(user);
            }
            foreach (Kunde kunde in db.Kunden) {
                db.Kunden.Remove(kunde);
            }
            foreach (Firma firma in db.Firmen) {
                db.Firmen.Remove(firma);
            }
            foreach (Produktgruppe produktgruppe in db.Produktgruppe) {
                db.Produktgruppe.Remove(produktgruppe);
            }
            foreach (ProduktgruppeKunde produktgruppe in db.ProduktgruppeKunden) {
                db.ProduktgruppeKunden.Remove(produktgruppe);
            }
            // Clear auto-increment counters
            db.Database.ExecuteSql($"DELETE FROM SQLITE_SEQUENCE WHERE NAME = 'Kunden'");
            db.Database.ExecuteSql($"DELETE FROM SQLITE_SEQUENCE WHERE NAME = 'Firmen'");
            db.Database.ExecuteSql($"DELETE FROM SQLITE_SEQUENCE WHERE NAME = 'Produktgruppe'");
            db.Database.ExecuteSql($"DELETE FROM SQLITE_SEQUENCE WHERE NAME = 'ProduktgruppeKunden'");
            db.Database.ExecuteSql($"DELETE FROM SQLITE_SEQUENCE WHERE NAME = 'Users'");
            db.SaveChanges();

            Console.WriteLine("Creating Users");
            db.Add(new User { Name = "Matthias", Passwort = "matt" });
            db.Add(new User { Name = "Heinrich", Passwort = "hein" });
            db.Add(new User { Name = "Kevin", Passwort = "kev" });
            db.Add(new User { Name = "Serhan", Passwort = "ser" });

            Console.WriteLine("Creating Produktgruppen");
            db.Add(new Produktgruppe { ProduktgruppeId = 1, Name = "Laptop" });
            db.Add(new Produktgruppe { ProduktgruppeId = 2, Name = "Rechner" });
            db.Add(new Produktgruppe { ProduktgruppeId = 3, Name = "Server" });

            Console.WriteLine("Creating Kunden");
            db.Add(new Kunde { KundeId = 1, Vorname = "Delete", Nachname = "Me", Firmenvertreter = false, Foto = ":^)", Hausnummer = "E2FI4", Ort = "Stuttgart", PLZ = 0711, Strasse = "Obere" });
            db.Add(new Kunde { KundeId = 2, Vorname = "Me", Nachname = "Update", Firmenvertreter = true, FirmaId = 12, Foto = "<:", Hausnummer = "12", Ort = "Weil", PLZ = 123, Strasse = "Untere" });
            db.Add(new Kunde { KundeId = 3, Vorname = "Product", Nachname = "Owner", Firmenvertreter = false, Foto = "", Hausnummer = "", Ort = "", PLZ = 0, Strasse = "" });

            Console.WriteLine("Creating Firma");
            db.Add(new Firma { FirmaId = 12, Name = "Firma XY" });

            Console.WriteLine("Creating Produktgruppe-Kunde relations");
            db.Add(new ProduktgruppeKunde { KundeId = 2, ProduktgruppeId = 1 });
            db.Add(new ProduktgruppeKunde { KundeId = 2, ProduktgruppeId = 2 });
            db.Add(new ProduktgruppeKunde { KundeId = 2, ProduktgruppeId = 3 });

            db.SaveChanges();
        }
    }
}
