using ApiContextNamespace;
using Database;
using MesseContextNamespace;
using System.Text;
using System.Text.Json;
using System.Net.Http.Headers;
using API.Controllers;
using Microsoft.AspNetCore.Http;
using System.Net.Http;

namespace DatabaseSync {
    internal class Program {
        public static void Main(string[] args) {
            MesseContext local = new MesseContext();
            // ApiContext api = new ApiContext();

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
            ClearLocalStorage(local);
            FetchFromAPI(local);
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
        }

        // Syncs _Produktgruppe_n from company DB to local DB
        private static void FetchFromAPI(MesseContext local) {
            //foreach (Produktgruppe produktgruppe in api.Produktgruppe) {
            //    local.Produktgruppe.Add(produktgruppe);
            //}
        }
    }
}
