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
    public class FuelTypesController : ControllerBase
    {
        private readonly NpgSqlDataContext _context;

        public FuelTypesController(NpgSqlDataContext context)
        {
            _context = context;
        }

        // GET: api/FuelTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FuelType>>> GetFuelType()
        {
            return await _context.FuelType.ToListAsync();
        }

        // GET: api/FuelTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FuelType>> GetFuelType(int id)
        {
            var fuelType = await _context.FuelType.FindAsync(id);

            if (fuelType == null)
            {
                return NotFound();
            }

            return fuelType;
        }

        // PUT: api/FuelTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFuelType(int id, FuelType fuelType)
        {
            if (id != fuelType.FuelTypeId)
            {
                return BadRequest();
            }

            _context.Entry(fuelType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FuelTypeExists(id))
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

        // POST: api/FuelTypes
        [HttpPost]
        public async Task<ActionResult<FuelType>> PostFuelType(FuelType fuelType)
        {
            _context.FuelType.Add(fuelType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFuelType", new { id = fuelType.FuelTypeId }, fuelType);
        }

        // DELETE: api/FuelTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FuelType>> DeleteFuelType(int id)
        {
            var fuelType = await _context.FuelType.FindAsync(id);
            if (fuelType == null)
            {
                return NotFound();
            }

            _context.FuelType.Remove(fuelType);
            await _context.SaveChangesAsync();

            return fuelType;
        }

        private bool FuelTypeExists(int id)
        {
            return _context.FuelType.Any(e => e.FuelTypeId == id);
        }
    }
}
