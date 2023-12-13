using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

public class MesseContext : DbContext
{
    public DbSet<Kunde> Kunden { get; set; }
    public DbSet<Firma> Firmen { get; set; }
    public DbSet<Produktgruppe> Produktgruppe { get; set; }
    public DbSet<ProduktgruppeKunde> ProduktgruppeKunden { get; set; }
    public DbSet<User> Users { get; set; }


    public string DbPath { get; }

    public MesseContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "messe.db");
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}

public class Kunde
{
    public int KundeId { get; set; }
    public required string Vorname { get; set; }
    public required string Nachname { get; set; }
    public required int PLZ { get; set; }
    public required string Ort { get; set; }
    public required string Strasse { get; set; }
    public required string Hausnummer { get; set; }
    public required string Foto { get; set; }
    public required string Firmenvertreter { get; set; }
    
    public int? FirmaId { get; set; }
}

public class Firma
{
    public int FirmaId { get; set; }
    public required string Name { get; set; }
}

public class Produktgruppe
{
    public int ProduktgruppeId { get; set; }
    public required string Name { get; set; }
}

public class ProduktgruppeKunde
{
    public int ProduktgruppeKundeId { get; set; }
    public required int ProduktgruppeId { get; set; }
    public required int KundeId { get; set; }
}
public class User
{
    public int UserId { get; set; }
    public required string Name { get; set; }
    public required string Passwort { get; set; }
}