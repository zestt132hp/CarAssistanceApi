using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarAssistance.Data;
using CarAssistance.Models;

namespace CarAssistance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufactersController : ControllerBase
    {
        private readonly NpgSqlDataContext _context;

        public ManufactersController(NpgSqlDataContext context)
        {
            _context = context;
        }

        // GET: api/Manufacters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Manufacter>>> GetManufacter()
        {
            return await _context.Manufacter.ToListAsync();
        }

        // GET: api/Manufacters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Manufacter>> GetManufacter(int id)
        {
            var manufacter = await _context.Manufacter.FindAsync(id);

            if (manufacter == null)
            {
                return NotFound();
            }

            return manufacter;
        }

        // PUT: api/Manufacters/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutManufacter(int id, Manufacter manufacter)
        {
            if (id != manufacter.ManufacterId)
            {
                return BadRequest();
            }

            _context.Entry(manufacter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ManufacterExists(id))
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

        // POST: api/Manufacters
        [HttpPost]
        public async Task<ActionResult<Manufacter>> PostManufacter(Manufacter manufacter)
        {
            _context.Manufacter.Add(manufacter);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetManufacter", new { id = manufacter.ManufacterId }, manufacter);
        }

        // DELETE: api/Manufacters/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Manufacter>> DeleteManufacter(int id)
        {
            var manufacter = await _context.Manufacter.FindAsync(id);
            if (manufacter == null)
            {
                return NotFound();
            }

            _context.Manufacter.Remove(manufacter);
            await _context.SaveChangesAsync();

            return manufacter;
        }

        private bool ManufacterExists(int id)
        {
            return _context.Manufacter.Any(e => e.ManufacterId == id);
        }
    }
}
