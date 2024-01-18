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

        private static void FetchFromAPI(MesseContext local, ApiContext api) {
            foreach (User user in api.Users) {
                local.Users.Add(user);
            }
            foreach (Produktgruppe produktgruppe in api.Produktgruppe) {
                local.Produktgruppe.Add(produktgruppe);
            }
        }
    }
}
