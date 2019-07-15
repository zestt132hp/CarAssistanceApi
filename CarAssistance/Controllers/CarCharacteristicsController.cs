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
    public class CarCharacteristicsController : ControllerBase
    {
        private readonly NpgSqlDataContext _context;

        public CarCharacteristicsController(NpgSqlDataContext context)
        {
            _context = context;
        }

        // GET: api/CarCharacteristics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarCharacteristics>>> GetCarCharacteristics_1()
        {
            return await _context.CarCharacteristics.ToListAsync();
        }

        // GET: api/CarCharacteristics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarCharacteristics>> GetCarCharacteristics(int id)
        {
            var carCharacteristics = await _context.CarCharacteristics.FindAsync(id);

            if (carCharacteristics == null)
            {
                return NotFound();
            }

            return carCharacteristics;
        }

        // PUT: api/CarCharacteristics/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarCharacteristics(int id, CarCharacteristics carCharacteristics)
        {
            if (id != carCharacteristics.CarCharacteristicsId)
            {
                return BadRequest();
            }

            _context.Entry(carCharacteristics).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarCharacteristicsExists(id))
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

        // POST: api/CarCharacteristics
        [HttpPost]
        public async Task<ActionResult<CarCharacteristics>> PostCarCharacteristics(CarCharacteristics carCharacteristics)
        {
            _context.CarCharacteristics.Add(carCharacteristics);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarCharacteristics", new { id = carCharacteristics.CarCharacteristicsId }, carCharacteristics);
        }

        // DELETE: api/CarCharacteristics/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CarCharacteristics>> DeleteCarCharacteristics(int id)
        {
            var carCharacteristics = await _context.CarCharacteristics.FindAsync(id);
            if (carCharacteristics == null)
            {
                return NotFound();
            }

            _context.CarCharacteristics.Remove(carCharacteristics);
            await _context.SaveChangesAsync();

            return carCharacteristics;
        }

        private bool CarCharacteristicsExists(int id)
        {
            return _context.CarCharacteristics.Any(e => e.CarCharacteristicsId == id);
        }
    }
}
