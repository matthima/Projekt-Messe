using Microsoft.EntityFrameworkCore;

namespace Database {
    public abstract class BaseContext : DbContext {
        public BaseContext() { }
        public BaseContext(DbContextOptions options) : base(options) { }

        public DbSet<Kunde> Kunden { get; set; }
        public DbSet<Firma> Firmen { get; set; }
        public DbSet<Produktgruppe> Produktgruppe { get; set; }
        public DbSet<ProduktgruppeKunde> ProduktgruppeKunden { get; set; }
        public DbSet<User> Users { get; set; }


        public string DbPath { get; set; }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={this.DbPath}");

        // returns all _Produktgruppe_n, ordered by name
        public Produktgruppe[] GetProduktgruppenOrderedByName() {
            return this.Produktgruppe.OrderBy(p => p.Name).ToArray();
        }

        // return a _Produktgruppe_ with the matching name
        public Produktgruppe GetProduktgruppeByName(string name) {
            return this.Produktgruppe.Where(p => p.Name == name).First();
        }

        public Firma AddFirma(Firma firma) {
            this.Firmen.Add(firma);
            this.SaveChanges();
            return firma;
        }

        // Inserts a _ProduktgruppeKunde_ relation if it does not exist yet
        public ProduktgruppeKunde[] UpsertRelationKundeProduktgruppe(Kunde kunde, Produktgruppe[] ausgewaehlteProduktgruppen) {
            List<ProduktgruppeKunde> produktgruppeKunden = new List<ProduktgruppeKunde>();
            foreach (Produktgruppe produktgruppe in ausgewaehlteProduktgruppen) {
                ProduktgruppeKunde newProduktgruppeKunde = new ProduktgruppeKunde { KundeId = kunde.KundeId, ProduktgruppeId = produktgruppe.ProduktgruppeId };
                ProduktgruppeKunde produktgruppeKunde = this.GetProduktgruppeKunde(newProduktgruppeKunde);
                if (produktgruppeKunde == null) {
                    produktgruppeKunden.Add(this.UpsertProduktgruppeKunde(newProduktgruppeKunde));
                }
                else {
                    produktgruppeKunden.Add(newProduktgruppeKunde);
                }
            }
            return produktgruppeKunden.ToArray();
        }

        public ProduktgruppeKunde UpsertProduktgruppeKunde(ProduktgruppeKunde produktgruppeKunde) {
            ProduktgruppeKunde[] pk = this.ProduktgruppeKunden.Where(pk => pk.KundeId == produktgruppeKunde.KundeId && pk.ProduktgruppeId == produktgruppeKunde.ProduktgruppeId).ToArray();
            if (pk.Length == 0) {
                this.ProduktgruppeKunden.Add(produktgruppeKunde);
                this.SaveChanges();
                return produktgruppeKunde;
            }
            return pk[0];
        }


        public Kunde AddKunde(Kunde kunde) {
            this.Kunden.Add(kunde);
            this.SaveChanges();
            return kunde;
        }

        // returns the _Firma_ with matching attributes if it exists
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

        // returns the _Kunde_ with matching attributes if it exists
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


        // returns the _ProduktgruppeKunde_ with matching attributes if it exists
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

        // inserts a _Firma_ if it does not exist yet
        public Firma UpsertFirma(Firma newFirma) {
            Firma firma = this.GetFirma(newFirma);
            if (firma == null) {
                return this.AddFirma(newFirma);
            }
            return firma;
        }

        // inserts a _Kunde_ if it does not exist yet
        public Kunde UpsertKunde(Kunde newKunde) {
            Kunde kunde = this.GetKunde(newKunde);
            if (kunde == null) {
                return this.AddKunde(newKunde);
            }
            return kunde;
        }
    }
}
