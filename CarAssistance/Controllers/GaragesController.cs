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
    public class GaragesController : ControllerBase
    {
        private readonly NpgSqlDataContext _context;

        public GaragesController(NpgSqlDataContext context)
        {
            _context = context;
        }

        // GET: api/Garages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Garage>>> GetGarage()
        {
            return await _context.Garage.ToListAsync();
        }

        // GET: api/Garages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Garage>> GetGarage(int id)
        {
            var garage = await _context.Garage.FindAsync(id);

            if (garage == null)
            {
                return NotFound();
            }

            return garage;
        }

        // PUT: api/Garages/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGarage(int id, Garage garage)
        {
            if (id != garage.GarageId)
            {
                return BadRequest();
            }

            _context.Entry(garage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GarageExists(id))
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

        // POST: api/Garages
        [HttpPost]
        public async Task<ActionResult<Garage>> PostGarage(Garage garage)
        {
            _context.Garage.Add(garage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGarage", new { id = garage.GarageId }, garage);
        }

        // DELETE: api/Garages/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Garage>> DeleteGarage(int id)
        {
            var garage = await _context.Garage.FindAsync(id);
            if (garage == null)
            {
                return NotFound();
            }

            _context.Garage.Remove(garage);
            await _context.SaveChangesAsync();

            return garage;
        }

        private bool GarageExists(int id)
        {
            return _context.Garage.Any(e => e.GarageId == id);
        }
    }
}
