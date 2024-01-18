using ApiContextNamespace;
using Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// Der Controller 'kundenKartenController' ist für die Verarbeitung von HTTP-Anforderungen im Kontext der Kundendaten-API zuständig.
// Jede Methode auf dem Controller entspricht einer oder mehreren URIs.

namespace MesseAPI.Controllers {
    //[Authorize] // Endpunkte schützen
    [Route("api/[controller]")]
    [ApiController]
    public class kundenKartenController : ControllerBase {
        private readonly ApiContext _context;

        // Der Konstruktor des Controllers, der den Datenbankkontext 'ApiContext' als Abhängigkeit akzeptiert.
        public kundenKartenController(ApiContext context) {
            this._context = context;
        }

        // GET: api/kundenKarten
        // Diese Methode gibt alle Kundendaten zurück.
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kunde>>> GetkundenKarte() {
            // Wenn keine Kundendaten vorhanden sind, wird NotFound zurückgegeben.
            if (this._context.Kunden == null) {
                return this.NotFound();
            }

            // Andernfalls werden alle Kundendaten als Liste zurückgegeben.
            return await this._context.Kunden.ToListAsync();
        }

        // GET: api/kundenKarten/5
        // Diese Methode gibt die Kundendaten mit der angegebenen ID zurück.
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Kunde>> GetkundenKarte(int id) {
            // Wenn keine Kundendaten vorhanden sind, wird NotFound zurückgegeben.
            if (this._context.Kunden == null) {
                return this.NotFound();
            }

            // Andernfalls werden die Kundendaten mit der angegebenen ID zurückgegeben.
            Kunde? kundenKarte = await this._context.Kunden.FindAsync(id);

            // Wenn keine Kundendaten mit der angegebenen ID gefunden werden, wird NotFound zurückgegeben.
            if (kundenKarte == null) {
                return this.NotFound();
            }

            // Andernfalls werden die Kundendaten zurückgegeben.
            return kundenKarte;
        }

        // PUT: api/kundenKarten/5
        // Diese Methode aktualisiert die Kundendaten mit der angegebenen ID.
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutkundenKarte(int id, Kunde kundenKarte) {
            // Wenn die ID in der Anfrage nicht mit der ID in den Kundendaten übereinstimmt, wird BadRequest zurückgegeben.
            if (id != kundenKarte.KundeId) {
                return this.BadRequest();
            }

            // Der Zustand der Kundendaten wird auf "Geändert" gesetzt, um die Aktualisierung durchzuführen.
            this._context.Entry(kundenKarte).State = EntityState.Modified;

            try {
                // Die Änderungen werden in der Datenbank gespeichert.
                await this._context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) {
                // Falls ein gleichzeitiger Aktualisierungskonflikt auftritt und die Kundendaten nicht gefunden werden,
                // wird NotFound zurückgegeben. Andernfalls wird eine Ausnahme ausgelöst.
                if (!this.kundenKarteExists(id)) {
                    return this.NotFound();
                }
                else {
                    throw;
                }
            }

            // Wenn die Aktualisierung erfolgreich ist, wird NoContent zurückgegeben.
            return this.NoContent();
        }

        // POST: api/kundenKarten
        // Diese Methode erstellt eine neue Kundendaten.
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Kunde>> PostkundenKarte(Kunde kundenKarte) {
            // Wenn keine Kundendaten vorhanden sind, wird Problem mit einer Fehlermeldung zurückgegeben.
            if (this._context.Kunden == null) {
                return this.Problem("Entity set 'ApiContext.Kunden' is null.");
            }

            // Die neuen Kundendaten werden hinzugefügt.
            this._context.Kunden.Add(kundenKarte);
            // Die Änderungen werden in der Datenbank gespeichert.
            await this._context.SaveChangesAsync();

            // Es wird CreatedAtAction zurückgegeben, um die neu erstellten Kundendaten anzuzeigen.
            return this.CreatedAtAction(nameof(GetkundenKarte), new { id = kundenKarte.KundeId }, kundenKarte);
        }

        // DELETE: api/kundenKarten/5
        // Diese Methode löscht die Kundendaten mit der angegebenen ID.
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletekundenKarte(int id) {
            // Wenn keine Kundendaten vorhanden sind, wird NotFound zurückgegeben.
            if (this._context.Kunden == null) {
                return this.NotFound();
            }

            // Die Kundendaten mit der angegebenen ID werden gesucht.
            Kunde? kundenKarte = await this._context.Kunden.FindAsync(id);

            // Wenn keine Kundendaten mit der angegebenen ID gefunden werden, wird NotFound zurückgegeben.
            if (kundenKarte == null) {
                return this.NotFound();
            }

            // Die Kundendaten werden aus der Datenbank entfernt.
            this._context.Kunden.Remove(kundenKarte);
            // Die Änderungen werden in der Datenbank gespeichert.
            await this._context.SaveChangesAsync();

            // Wenn die Löschung erfolgreich ist, wird NoContent zurückgegeben.
            return this.NoContent();
        }

        // Private Hilfsmethode zur Überprüfung, ob Kundendaten mit der angegebenen ID vorhanden sind.
        private bool kundenKarteExists(int id) {
            return (this._context.Kunden?.Any(e => e.KundeId == id)).GetValueOrDefault();
        }
    }
}