using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Database;
using ApiContextNamespace;

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
            _context = context;
        }

        // GET: api/kundenKarten
        // Diese Methode gibt alle Kundendaten zurück.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kunde>>> GetkundenKarte() {
            // Wenn keine Kundendaten vorhanden sind, wird NotFound zurückgegeben.
            if (_context.Kunden == null) {
                return NotFound();
            }

            // Andernfalls werden alle Kundendaten als Liste zurückgegeben.
            return await _context.Kunden.ToListAsync();
        }

        // GET: api/kundenKarten/5
        // Diese Methode gibt die Kundendaten mit der angegebenen ID zurück.
        [HttpGet("{id}")]
        public async Task<ActionResult<Kunde>> GetkundenKarte(int id) {
            // Wenn keine Kundendaten vorhanden sind, wird NotFound zurückgegeben.
            if (_context.Kunden == null) {
                return NotFound();
            }

            // Andernfalls werden die Kundendaten mit der angegebenen ID zurückgegeben.
            var kundenKarte = await _context.Kunden.FindAsync(id);

            // Wenn keine Kundendaten mit der angegebenen ID gefunden werden, wird NotFound zurückgegeben.
            if (kundenKarte == null) {
                return NotFound();
            }

            // Andernfalls werden die Kundendaten zurückgegeben.
            return kundenKarte;
        }

        // PUT: api/kundenKarten/5
        // Diese Methode aktualisiert die Kundendaten mit der angegebenen ID.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutkundenKarte(int id, Kunde kundenKarte) {
            // Wenn die ID in der Anfrage nicht mit der ID in den Kundendaten übereinstimmt, wird BadRequest zurückgegeben.
            if (id != kundenKarte.KundeId) {
                return BadRequest();
            }

            // Der Zustand der Kundendaten wird auf "Geändert" gesetzt, um die Aktualisierung durchzuführen.
            _context.Entry(kundenKarte).State = EntityState.Modified;

            try {
                // Die Änderungen werden in der Datenbank gespeichert.
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) {
                // Falls ein gleichzeitiger Aktualisierungskonflikt auftritt und die Kundendaten nicht gefunden werden,
                // wird NotFound zurückgegeben. Andernfalls wird eine Ausnahme ausgelöst.
                if (!kundenKarteExists(id)) {
                    return NotFound();
                }
                else {
                    throw;
                }
            }

            // Wenn die Aktualisierung erfolgreich ist, wird NoContent zurückgegeben.
            return NoContent();
        }

        // POST: api/kundenKarten
        // Diese Methode erstellt eine neue Kundendaten.
        [HttpPost]
        public async Task<ActionResult<Kunde>> PostkundenKarte(Kunde kundenKarte) {
            // Wenn keine Kundendaten vorhanden sind, wird Problem mit einer Fehlermeldung zurückgegeben.
            if (_context.Kunden == null) {
                return Problem("Entity set 'ApiContext.Kunden' is null.");
            }

            // Die neuen Kundendaten werden hinzugefügt.
            _context.Kunden.Add(kundenKarte);
            // Die Änderungen werden in der Datenbank gespeichert.
            await _context.SaveChangesAsync();

            // Es wird CreatedAtAction zurückgegeben, um die neu erstellten Kundendaten anzuzeigen.
            return CreatedAtAction(nameof(GetkundenKarte), new { id = kundenKarte.KundeId }, kundenKarte);
        }

        // DELETE: api/kundenKarten/5
        // Diese Methode löscht die Kundendaten mit der angegebenen ID.
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletekundenKarte(int id) {
            // Wenn keine Kundendaten vorhanden sind, wird NotFound zurückgegeben.
            if (_context.Kunden == null) {
                return NotFound();
            }

            // Die Kundendaten mit der angegebenen ID werden gesucht.
            var kundenKarte = await _context.Kunden.FindAsync(id);

            // Wenn keine Kundendaten mit der angegebenen ID gefunden werden, wird NotFound zurückgegeben.
            if (kundenKarte == null) {
                return NotFound();
            }

            // Die Kundendaten werden aus der Datenbank entfernt.
            _context.Kunden.Remove(kundenKarte);
            // Die Änderungen werden in der Datenbank gespeichert.
            await _context.SaveChangesAsync();

            // Wenn die Löschung erfolgreich ist, wird NoContent zurückgegeben.
            return NoContent();
        }

        // Private Hilfsmethode zur Überprüfung, ob Kundendaten mit der angegebenen ID vorhanden sind.
        private bool kundenKarteExists(int id) {
            return (_context.Kunden?.Any(e => e.KundeId == id)).GetValueOrDefault();
        }
    }
}