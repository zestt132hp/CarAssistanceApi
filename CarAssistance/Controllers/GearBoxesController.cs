using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarAssistance.Data;
using CarAssistance.Models;

namespace CarAssistance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GearBoxesController : ControllerBase
    {
        private readonly NpgSqlDataContext _context;

        public GearBoxesController(NpgSqlDataContext context)
        {
            _context = context;
        }

        // GET: api/GearBoxes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GearBox>>> GetGearBox()
        {
            return await _context.GearBox.ToListAsync();
        }

        // GET: api/GearBoxes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GearBox>> GetGearBox(int id)
        {
            var gearBox = await _context.GearBox.FindAsync(id);

            if (gearBox == null)
            {
                return NotFound();
            }

            return gearBox;
        }

        // PUT: api/GearBoxes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGearBox(int id, GearBox gearBox)
        {
            if (id != gearBox.GearBoxId)
            {
                return BadRequest();
            }

            _context.Entry(gearBox).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GearBoxExists(id))
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

        // POST: api/GearBoxes
        [HttpPost]
        public async Task<ActionResult<GearBox>> PostGearBox(GearBox gearBox)
        {
            _context.GearBox.Add(gearBox);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGearBox", new { id = gearBox.GearBoxId }, gearBox);
        }

        // DELETE: api/GearBoxes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GearBox>> DeleteGearBox(int id)
        {
            var gearBox = await _context.GearBox.FindAsync(id);
            if (gearBox == null)
            {
                return NotFound();
            }

            _context.GearBox.Remove(gearBox);
            await _context.SaveChangesAsync();

            return gearBox;
        }

        private bool GearBoxExists(int id)
        {
            return _context.GearBox.Any(e => e.GearBoxId == id);
        }
    }
}
