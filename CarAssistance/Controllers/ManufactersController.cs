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
    public class ManufactersController : ControllerBases
    {
        private readonly NpgSqlDataContext _context;

        public ManufactersController(NpgSqlDataContext context)
        {
            _context = context;
        }

        // GET: api/Manufacters
        [HttpGet, Route("manufacters")]
        public async Task<ActionResult<IEnumerable<Manufacters>>> GetManufacter()
        {
            return await _context.Manufacter.ToListAsync();
        }

        // GET: api/Manufacters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Manufacters>> GetManufacter(int id)
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
        public async Task<IActionResult> PutManufacter(int id, Manufacters manufacter)
        {
            if (id != manufacter?.Id)
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
        public async Task<ActionResult<Manufacters>> PostManufacter(Manufacters manufacter)
        {
            _context.Manufacter.Add(manufacter);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetManufacter", new { id = manufacter?.Id }, manufacter);
        }

        // DELETE: api/Manufacters/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Manufacters>> DeleteManufacter(int id)
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
            return _context.Manufacter.Any(e => e.Id == id);
        }
    }
}
