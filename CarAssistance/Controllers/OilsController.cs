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
    public class OilsController : ControllerBases
    {
        private readonly NpgSqlDataContext _context;

        public OilsController(NpgSqlDataContext context)
        {
            _context = context;
        }

        // GET: api/Oils
        [HttpGet, Route("oils")]
        public async Task<ActionResult<IEnumerable<OilInfo>>> GetOil()
        {
            return await _context.OilInfo.ToListAsync();
        }

        // GET: api/Oils/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OilInfo>> GetOil(int id)
        {
            var oil = await _context.OilInfo.FindAsync(id);

            if (oil == null)
            {
                return NotFound();
            }

            return oil;
        }

        // PUT: api/Oils/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOil(int id, OilInfo oil)
        {
            if (id != oil?.Id)
            {
                return BadRequest();
            }

            _context.Entry(oil).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OilExists(id))
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

        // POST: api/Oils
        [HttpPost]
        public async Task<ActionResult<OilInfo>> PostOil(OilInfo oil)
        {
            _context.OilInfo.Add(oil);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOil", new { id = oil?.Id }, oil);
        }

        // DELETE: api/Oils/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OilInfo>> DeleteOil(int id)
        {
            var oil = await _context.OilInfo.FindAsync(id);
            if (oil == null)
            {
                return NotFound();
            }

            _context.OilInfo.Remove(oil);
            await _context.SaveChangesAsync();

            return oil;
        }

        private bool OilExists(int id)
        {
            return _context.OilInfo.Any(e => e.Id == id);
        }
    }
}
