using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database {
    public abstract class BaseContext : DbContext {
        public BaseContext() { }
        public BaseContext(DbContextOptions options) : base(options) {}

        public DbSet<Kunde> Kunden { get; set; }
        public DbSet<Firma> Firmen { get; set; }
        public DbSet<Produktgruppe> Produktgruppe { get; set; }
        public DbSet<ProduktgruppeKunde> ProduktgruppeKunden { get; set; }
        public DbSet<User> Users { get; set; }


        public string DbPath { get; set; }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");

        public Produktgruppe[] GetProduktgruppenOrderedByName() {
            return this.Produktgruppe.OrderBy(p => p.Name).ToArray();
        }

        public Produktgruppe GetProduktgruppeByName(string name) {
            return this.Produktgruppe.Where(p => p.Name == name).First();
        }

        public Firma AddFirma(Firma firma) {
            this.Firmen.Add(firma);
            this.SaveChanges();
            return firma;
        }
        public ProduktgruppeKunde AddProduktgruppeKunde(ProduktgruppeKunde produktgruppeKunde) {
            this.ProduktgruppeKunden.Add(produktgruppeKunde);
            this.SaveChanges();
            return produktgruppeKunde;
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

        public ProduktgruppeKunde? GetProduktgruppeKunde(ProduktgruppeKunde target) {
            ProduktgruppeKunde[] produktgruppeKunde = this.ProduktgruppeKunden.Where(produktgruppeKunde =>
                produktgruppeKunde.ProduktgruppeId == target.ProduktgruppeId &&
                produktgruppeKunde.KundeId == target.KundeId
            ).ToArray();
            if (produktgruppeKunde.Length == 1) {
                return produktgruppeKunde[0];
            }
            else if (produktgruppeKunde.Length > 1) {
                throw new Exception("Multiple 'ProduktgruppeKunde' that represent the same relation found");
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
        public ProduktgruppeKunde[] UpsertRelationKundeProduktgruppe(Kunde kunde, Produktgruppe[] ausgewaehlteProduktgruppen) {
            List<ProduktgruppeKunde> produktgruppeKunden = new List<ProduktgruppeKunde>();
            foreach (Produktgruppe produktgruppe in ausgewaehlteProduktgruppen) {
                ProduktgruppeKunde newProduktgruppeKunde = new ProduktgruppeKunde { KundeId = kunde.KundeId, ProduktgruppeId = produktgruppe.ProduktgruppeId };
                ProduktgruppeKunde produktgruppeKunde = GetProduktgruppeKunde(newProduktgruppeKunde);
                if (produktgruppeKunde == null) {
                    produktgruppeKunden.Add(this.AddProduktgruppeKunde(newProduktgruppeKunde));
                }
                else {
                    produktgruppeKunden.Add(newProduktgruppeKunde);
                }
            }
            return produktgruppeKunden.ToArray();
        }
    }
}
