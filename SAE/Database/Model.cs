using Microsoft.EntityFrameworkCore;

public class MesseContext : DbContext {
    public DbSet<Kunde> Kunden { get; set; }
    public DbSet<Firma> Firmen { get; set; }
    public DbSet<Produktgruppe> Produktgruppe { get; set; }
    public DbSet<ProduktgruppeKunde> ProduktgruppeKunden { get; set; }
    public DbSet<User> Users { get; set; }


    public string DbPath { get; }

    public MesseContext() {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "messe.db");
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");

    public Produktgruppe[] GetProduktgruppenByName() {
        return this.Produktgruppe.OrderBy(p => p.Name).ToArray();
    }

    public Firma AddFirma(Firma firma) {
        this.Firmen.Add(firma);
        this.SaveChanges();
        return firma;
    }

    public Kunde AddKunde(Kunde kunde) {
        this.Kunden.Add(kunde);
        this.SaveChanges();
        return kunde;
    }

    public Firma? GetFirma(Firma target) {
        Firma[] firma = this.Firmen.Where(firma => firma.Name == target.Name).ToArray();
        if (firma.Length == 1) {
            return firma[0];
        }
        else if (firma.Length > 1) {
            throw new Exception("Multiple 'Firma' with same name found");
        }
        else {
            return null;
        }
    }

    public Kunde? GetKunde(Kunde target) {
        Kunde[] kunde = this.Kunden.Where(kunde =>
            kunde.Vorname == target.Vorname &&
            kunde.Nachname == target.Nachname &&
            kunde.PLZ == target.PLZ &&
            kunde.Ort == target.Ort &&
            kunde.Strasse == target.Strasse &&
            kunde.Hausnummer == target.Hausnummer &&
            kunde.Firmenvertreter == target.Firmenvertreter &&
            kunde.FirmaId == target.FirmaId &&
            kunde.Foto == target.Foto
        ).ToArray();

        if (kunde.Length == 1) {
            return kunde[0];
        }
        else if (kunde.Length > 1) {
            throw new Exception("Multiple 'Kunde' with same name found");
        }
        else {
            return null;
        }
    }



    public Firma UpsertFirma(Firma newFirma) {
        Firma firma = GetFirma(newFirma);
        if (firma == null) {
            return this.AddFirma(newFirma);
        }
        return firma;
    }

    public Kunde UpsertKunde(Kunde newKunde) {
        Kunde kunde = GetKunde(newKunde);
        if (kunde == null) {
            return this.AddKunde(newKunde);
        }
        return kunde;
    }
}

public class Kunde {
    public int KundeId { get; set; }

    public required string Vorname { get; set; }
    public required string Nachname { get; set; }
    public required int PLZ { get; set; }
    public required string Ort { get; set; }
    public required string Strasse { get; set; }
    public required string Hausnummer { get; set; }
    public required string Foto { get; set; } // base 64 encoded
    public required bool Firmenvertreter { get; set; }

    public int? FirmaId { get; set; }
}

public class Firma {
    public int FirmaId { get; set; }
    public required string Name { get; set; }
}

public class Produktgruppe {
    public int ProduktgruppeId { get; set; }
    public required string Name { get; set; }
}

public class ProduktgruppeKunde {
    public int ProduktgruppeKundeId { get; set; }
    public required int ProduktgruppeId { get; set; }
    public required int KundeId { get; set; }
}
public class User {
    public int UserId { get; set; }
    public required string Name { get; set; }
    public required string Passwort { get; set; }
}