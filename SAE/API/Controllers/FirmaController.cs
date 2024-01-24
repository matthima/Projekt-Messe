using ApiContextNamespace;
using Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MesseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FirmaController : ControllerBase
    {
        private readonly ApiContext _context;

        public FirmaController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/Firma
        // returns all Firmen
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Firma>>> GetFirmen()
        {
            if (this._context.Firmen == null)
            {
                return this.NotFound();
            }
            return this._context.Firmen.ToList();
        }

        // POST: api/Firma
        // creates new firmen
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Firma>> PostFirmen(Firma firma)
        {
            // Check if table exists
            if (this._context.Firmen == null)
            {
                return this.Problem("Entity set 'ApiContext.Firmen' is null.");
            }

            this._context.Firmen.Add(firma);
            this._context.SaveChanges();

            return null;
        }
    }
}
