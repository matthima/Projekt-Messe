using ApiContextNamespace;
using Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// _kundenKartenController_ is responsible for handling HTTP-Requests for our customers' data
namespace MesseAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class KundenKartenController : ControllerBase {
        private readonly ApiContext _context;

        public KundenKartenController(ApiContext context) {
            this._context = context;
        }

        // GET: api/kundenKarten
        // returns all _Kunde_n
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kunde>>> GetkundenKarte() {
            if (this._context.Kunden == null) {
                return this.NotFound();
            }
            return this._context.Kunden.ToList();
        }

        // GET: api/kundenKarten/{id}
        // returns the _Kunde_ with the specified id
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Kunde>> GetkundenKarte(int id) {
            if (this._context.Kunden == null) {
                return this.NotFound();
            }

            // Tries to fetch the _Kunde_ with the specified id
            Kunde? kundenKarte = this._context.Kunden.Find(id);

            // If no _Kunde_ with the specified id exists, return NotFound
            if (kundenKarte == null) {
                return this.NotFound();
            }

            return kundenKarte;
        }

        // POST: api/kundenKarten
        // creates new _Kunde_
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Kunde>> PostkundenKarte([FromBody] Kunde kundenKarte) {
            // Check if table exists
            if (this._context.Kunden == null) {
                return this.Problem("Entity set 'ApiContext.Kunden' is null.");
            }

            this._context.Kunden.Add(kundenKarte);
            this._context.SaveChanges();

            // returns new _Kunde_ via CreatedAtAction
            return this.CreatedAtAction(nameof(GetkundenKarte), new { id = kundenKarte.KundeId }, kundenKarte);
        }

        // DELETE: api/kundenKarten/{id}
        // deletes the _Kunde_ with the specified id
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletekundenKarte(int id) {
            // check if table exists
            if (this._context.Kunden == null) {
                return this.NotFound();
            }

            // tries to fetch the _Kunde_ with the specified id
            Kunde? kundenKarte = this._context.Kunden.Find(id);

            if (kundenKarte == null) {
                return this.NotFound();
            }

            this._context.Kunden.Remove(kundenKarte);
            this._context.SaveChanges();

            // return NoContent on success
            return this.NoContent();
        }

        private bool kundenKarteExists(int id) {
            return (this._context.Kunden?.Any(e => e.KundeId == id)).GetValueOrDefault();
        }
    }
}