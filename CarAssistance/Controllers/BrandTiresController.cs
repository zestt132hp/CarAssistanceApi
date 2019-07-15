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
    public class BrandTiresController : ControllerBase
    {
        private readonly NpgSqlDataContext _context;

        public BrandTiresController(NpgSqlDataContext context)
        {
            _context = context;
        }

        // GET: api/BrandTires
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BrandTires>>> GetBrandTires()
        {
            return await _context.BrandTires.ToListAsync();
        }

        // GET: api/BrandTires/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BrandTires>> GetBrandTires(int id)
        {
            var brandTires = await _context.BrandTires.FindAsync(id);

            if (brandTires == null)
            {
                return NotFound();
            }

            return brandTires;
        }

        // PUT: api/BrandTires/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBrandTires(int id, BrandTires brandTires)
        {
            if (id != brandTires.Id)
            {
                return BadRequest();
            }

            _context.Entry(brandTires).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BrandTiresExists(id))
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

        // POST: api/BrandTires
        [HttpPost]
        public async Task<ActionResult<BrandTires>> PostBrandTires(BrandTires brandTires)
        {
            _context.BrandTires.Add(brandTires);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBrandTires", new { id = brandTires.Id }, brandTires);
        }

        // DELETE: api/BrandTires/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BrandTires>> DeleteBrandTires(int id)
        {
            var brandTires = await _context.BrandTires.FindAsync(id);
            if (brandTires == null)
            {
                return NotFound();
            }

            _context.BrandTires.Remove(brandTires);
            await _context.SaveChangesAsync();

            return brandTires;
        }

        private bool BrandTiresExists(int id)
        {
            return _context.BrandTires.Any(e => e.Id == id);
        }
    }
}
