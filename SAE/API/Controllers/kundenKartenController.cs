using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MesseAPI.Models;

// Objekt zum Verarbeiten von HTTP Anforderungen
//Jede Methode auf dem Controller entspricht einer oder mehreren URIs


namespace MesseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class kundenKartenController : ControllerBase
    {
        private readonly kundenContext _context;

        public kundenKartenController(kundenContext context)
        {
            _context = context;
        }

        // GET: api/kundenKarten
        [HttpGet]
        public async Task<ActionResult<IEnumerable<kundenKarte>>> GetkundenKarte()
        {
          if (_context.kundenKarte == null)
          {
              return NotFound();
          }
            return await _context.kundenKarte.ToListAsync();
        }

        // GET: api/kundenKarten/5
        [HttpGet("{id}")]
        public async Task<ActionResult<kundenKarte>> GetkundenKarte(int id)
        {
          if (_context.kundenKarte == null)
          {
              return NotFound();
          }
            var kundenKarte = await _context.kundenKarte.FindAsync(id);

            if (kundenKarte == null)
            {
                return NotFound();
            }

            return kundenKarte;
        }

        // PUT: api/kundenKarten/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutkundenKarte(int id, kundenKarte kundenKarte)
        {
            if (id != kundenKarte.Id)
            {
                return BadRequest();
            }

            _context.Entry(kundenKarte).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!kundenKarteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/kundenKarten
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<kundenKarte>> PostkundenKarte(kundenKarte kundenKarte)
        {
          if (_context.kundenKarte == null)
          {
              return Problem("Entity set 'kundenContext.kundenKarte'  is null.");
          }
            _context.kundenKarte.Add(kundenKarte);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetkundenKarte", new { id = kundenKarte.Id }, kundenKarte);
            return CreatedAtAction(nameof(GetkundenKarte), new { id = kundenKarte.Id }, kundenKarte);
        }

        // DELETE: api/kundenKarten/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletekundenKarte(int id)
        {
            if (_context.kundenKarte == null)
            {
                return NotFound();
            }
            var kundenKarte = await _context.kundenKarte.FindAsync(id);
            if (kundenKarte == null)
            {
                return NotFound();
            }

            _context.kundenKarte.Remove(kundenKarte);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool kundenKarteExists(int id)
        {
            return (_context.kundenKarte?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
