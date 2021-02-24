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
    public class TiresController : ControllerBases
    {
        private readonly NpgSqlDataContext _context;

        public TiresController(NpgSqlDataContext context)
        {
            _context = context;
        }

        // GET: api/Tires
        [HttpGet, Route("tires")]
        public async Task<ActionResult<IEnumerable<Tires>>> GetTires()
        {
            return await _context.Tires.ToListAsync();
        }

        // GET: api/Tires/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tires>> GetTires(int id)
        {
            var tires = await _context.Tires.FindAsync(id);

            if (tires == null)
            {
                return NotFound();
            }

            return tires;
        }

        // PUT: api/Tires/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTires(int id, Tires tires)
        {
            if (id != tires?.Id)
            {
                return BadRequest();
            }

            _context.Entry(tires).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TiresExists(id))
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

        // POST: api/Tires
        [HttpPost]
        public async Task<ActionResult<Tires>> PostTires(Tires tires)
        {
            _context.Tires.Add(tires);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTires", new { id = tires?.Id }, tires);
        }

        // DELETE: api/Tires/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tires>> DeleteTires(int id)
        {
            var tires = await _context.Tires.FindAsync(id);
            if (tires == null)
            {
                return NotFound();
            }

            _context.Tires.Remove(tires);
            await _context.SaveChangesAsync();

            return tires;
        }

        private bool TiresExists(int id)
        {
            return _context.Tires.Any(e => e.Id == id);
        }
    }
}
