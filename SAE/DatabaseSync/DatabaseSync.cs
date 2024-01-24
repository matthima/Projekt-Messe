using ApiContextNamespace;
using Database;
using MesseContextNamespace;
using System.Text;
using System.Text.Json;
using System.Net.Http.Headers;
using API.Controllers;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Runtime.Intrinsics.X86;

namespace DatabaseSync {
    internal class DatabaseSync {
        public static void Main(string[] args) {
            MesseContext local = new MesseContext();
            SyncDBs(local);
        }

        private static void SyncDBs(MesseContext local) {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7190/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


            StringContent postJSON = new StringContent(JsonSerializer.Serialize(new LoginDTO { UserName="Heinrich", Password="hein"}), Encoding.UTF8, "application/json");
            string authToken = client.PostAsync("Login/login", postJSON).GetAwaiter().GetResult().Content.ReadAsStringAsync().GetAwaiter().GetResult().Replace("\"", "");
            Console.WriteLine(authToken);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);
            foreach (Kunde kunde in local.Kunden) {
                postJSON = new StringContent(JsonSerializer.Serialize(kunde), Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync("kundenKarten", postJSON).GetAwaiter().GetResult();
                string responseText = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }
            foreach (Firma firma in local.Firmen) {
                postJSON = new StringContent(JsonSerializer.Serialize(firma), Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync("firma", postJSON).GetAwaiter().GetResult();
                string responseText = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }
            foreach (ProduktgruppeKunde pk in local.ProduktgruppeKunden) {
                postJSON = new StringContent(JsonSerializer.Serialize(pk), Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync("ProduktgruppeKunde", postJSON).GetAwaiter().GetResult();
                string responseText = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }
            ClearLocalStorage(local);
            FetchFromAPI(local, client);
            local.SaveChanges();
        }

        // Clears the local DB, keeping the auto-increment counters
        private static void ClearLocalStorage(MesseContext local) {
            foreach (User user in local.Users) {
                local.Users.Remove(user);
            }
            foreach (Kunde kunde in local.Kunden) {
                local.Kunden.Remove(kunde);
            }
            foreach (Produktgruppe produktgruppe in local.Produktgruppe) {
                local.Produktgruppe.Remove(produktgruppe);
            }
            foreach (ProduktgruppeKunde produktgruppe in local.ProduktgruppeKunden) {
                local.ProduktgruppeKunden.Remove(produktgruppe);
            }
            foreach (Firma firma in local.Firmen) {
                local.Firmen.Remove(firma);
            }
        }

        // Syncs _Produktgruppe_n from company DB to local DB
        private static void FetchFromAPI(MesseContext local, HttpClient client) {
            HttpResponseMessage response = client.GetAsync("Firma").GetAwaiter().GetResult();
            List<Firma> firmen = JsonSerializer.Deserialize<List<Firma>>(response.Content.ReadAsStringAsync().GetAwaiter().GetResult());
            foreach (Firma firma in firmen) {
                local.Firmen.Add(firma);
            }
            response = client.GetAsync("Produktgruppe").GetAwaiter().GetResult();
            Produktgruppe[] produktgruppen = JsonSerializer.Deserialize<Produktgruppe[]>(response.Content.ReadAsStringAsync().GetAwaiter().GetResult());
            foreach (Produktgruppe produktgruppe in produktgruppen) {
                local.Produktgruppe.Add(produktgruppe);
            }
        }
    }
}
