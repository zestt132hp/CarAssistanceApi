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
    public class OilsController : ControllerBase
    {
        private readonly NpgSqlDataContext _context;

        public OilsController(NpgSqlDataContext context)
        {
            _context = context;
        }

        // GET: api/Oils
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Oil>>> GetOil()
        {
            return await _context.Oil.ToListAsync();
        }

        // GET: api/Oils/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Oil>> GetOil(int id)
        {
            var oil = await _context.Oil.FindAsync(id);

            if (oil == null)
            {
                return NotFound();
            }

            return oil;
        }

        // PUT: api/Oils/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOil(int id, Oil oil)
        {
            if (id != oil.OilId)
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
        public async Task<ActionResult<Oil>> PostOil(Oil oil)
        {
            _context.Oil.Add(oil);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOil", new { id = oil.OilId }, oil);
        }

        // DELETE: api/Oils/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Oil>> DeleteOil(int id)
        {
            var oil = await _context.Oil.FindAsync(id);
            if (oil == null)
            {
                return NotFound();
            }

            _context.Oil.Remove(oil);
            await _context.SaveChangesAsync();

            return oil;
        }

        private bool OilExists(int id)
        {
            return _context.Oil.Any(e => e.OilId == id);
        }
    }
}
