using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database {
    internal class ExampleScript {
        public static void Example() {
            using var db = new MesseContext();
            // Note: This sample requires the database to be created before running.
            Console.WriteLine($"Database path: {db.DbPath}.");


            Console.WriteLine("Deleting Users");
            var user = db.Users
                .OrderBy(b => b.UserId).ToList();

            for (int i = 0; i < db.Users.Count(); i++) {
                db.Remove(user[i]);
            }
            db.SaveChanges();

            Console.WriteLine("Creating Users");
            db.Add(new User { Name = "Matthias", Passwort = "Test123" });

            db.Add(new User { Name = "Heinrich", Passwort = "Test123" });

            db.Add(new User { Name = "Kevin", Passwort = "Test123" });
            db.SaveChanges();

            Console.WriteLine("Deleting Produktgruppen");
            var produktgruppen = db.Produktgruppe
                .OrderBy(b => b.ProduktgruppeId).ToList();

            for (int i = 0; i < db.Produktgruppe.Count(); i++) {
                db.Remove(produktgruppen[i]);
            }
            db.SaveChanges();

            Console.WriteLine("Creating Produkte");
            db.Add(new Produktgruppe { Name = "Laptop" });

            db.Add(new Produktgruppe { Name = "Rechner" });

            db.Add(new Produktgruppe { Name = "Server" });
            db.SaveChanges();



            // Create
            /*Console.WriteLine("Inserting a new Element");
            db.Add(new Produktgruppe { Name = "Laptop" });
            db.SaveChanges();*/


            // Read
            /*
            Console.WriteLine("Querying for a Element");
            var kunden = db.Kunden.ToArray();
            foreach (Kunde kunde in kunden) {
                Console.WriteLine($"{kunde.KundeId} {kunde.Vorname} {kunde.Nachname} {kunde.Firmenvertreter} {((kunde.FirmaId != null) ? kunde.FirmaId : "keine FirmaId")}");
            }
            */

            /*
            // Update
            Console.WriteLine("Updating the Element");
            produktgruppe.Name = "Rechner";
            db.SaveChanges();
            Console.WriteLine(produktgruppe.Name);
            */

            /*// Delete
            Console.WriteLine("Delete the Element");
            db.Remove(blog);
            db.SaveChanges();
            */
        }
    }
}
