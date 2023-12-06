using System;
using System.Linq;
using System.Reflection.Metadata;

using var db = new MesseContext();

// Note: This sample requires the database to be created before running.
Console.WriteLine($"Database path: {db.DbPath}.");

// Create
/*Console.WriteLine("Inserting a new Element");
db.Add(new Produktgruppe { Name = "Laptop" });
db.SaveChanges();*/

// Read
Console.WriteLine("Querying for a Element");
var produktgruppe = db.Produktgruppe
    .Single(b => b.ProduktgruppeId == 2);
// Update
Console.WriteLine("Updating the Element");
produktgruppe.Name = "Rechner";
db.SaveChanges();
Console.WriteLine(produktgruppe.Name);

/*// Delete
Console.WriteLine("Delete the Element");
db.Remove(blog);
db.SaveChanges();
*/