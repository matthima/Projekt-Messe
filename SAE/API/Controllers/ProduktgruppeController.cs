using ApiContextNamespace;
using Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MesseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProduktgruppeController : ControllerBase
    {
        private readonly ApiContext _context;

        public ProduktgruppeController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/produktgruppe
        // returns all Produgtgruppen
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produktgruppe>>> GetProduktgruppen()
        {
            if (this._context.Produktgruppe == null)
            {
                return this.NotFound();
            }
            return this._context.Produktgruppe.ToList();
        }
    }
}
