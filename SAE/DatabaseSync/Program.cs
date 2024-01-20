using ApiContextNamespace;
using Database;
using MesseContextNamespace;

namespace DatabaseSync {
    internal class Program {
        public static void Main(string[] args) {
            MesseContext local = new MesseContext();
            ApiContext api = new ApiContext();

            SyncDBs(local, api);
        }

        private static void SyncDBs(MesseContext local, ApiContext api) {
            // Upsert all data from the local DB to the company's DB
            foreach (Kunde kunde in local.Kunden) {
                api.UpsertKunde(kunde);
            }

            foreach (Firma firma in local.Firmen) {
                api.UpsertFirma(firma);
            }

            foreach (ProduktgruppeKunde pk in local.ProduktgruppeKunden) {
                api.UpsertProduktgruppeKunde(pk);
            }
            ClearLocalStorage(local);
            FetchFromAPI(local, api);
            local.SaveChanges();
            api.SaveChanges();
        }

        // Clears the local DB, keeping the auto-increment counters
        private static void ClearLocalStorage(MesseContext local) {
            foreach (User user in local.Users) {
                local.Users.Remove(user);
            }
            foreach (Kunde kunde in local.Kunden) {
                local.Kunden.Remove(kunde);
            }
            foreach (Firma firma in local.Firmen) {
                local.Firmen.Remove(firma);
            }
            foreach (Produktgruppe produktgruppe in local.Produktgruppe) {
                local.Produktgruppe.Remove(produktgruppe);
            }
            foreach (ProduktgruppeKunde produktgruppe in local.ProduktgruppeKunden) {
                local.ProduktgruppeKunden.Remove(produktgruppe);
            }
        }

        // Syncs _Produktgruppe_n from company DB to local DB
        private static void FetchFromAPI(MesseContext local, ApiContext api) {
            foreach (Produktgruppe produktgruppe in api.Produktgruppe) {
                local.Produktgruppe.Add(produktgruppe);
            }
        }
    }
}
