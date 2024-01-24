using ApiContextNamespace;
using Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MesseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProduktgruppeKundeController : ControllerBase
    {
        private readonly ApiContext _context;

        public ProduktgruppeKundeController(ApiContext context)
        {
            _context = context;
        }

        // POST: api/ProduktgruppeKunde
        // creates new ProduktgruppeKunde
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<ProduktgruppeKunde>> PostProduktgruppeKunde(ProduktgruppeKunde produktgruppeKunde)
        {
            // Check if table exists
            if (this._context.ProduktgruppeKunden == null)
            {
                return this.Problem("Entity set 'ApiContext.ProduktgruppeKunde' is null.");
            }

            this._context.ProduktgruppeKunden.Add(produktgruppeKunde);
            this._context.SaveChanges();

            return null;
        }
    }
}
