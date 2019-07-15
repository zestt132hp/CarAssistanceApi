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
    public class BodyTypesController : ControllerBase
    {
        private readonly NpgSqlDataContext _context;

        public BodyTypesController(NpgSqlDataContext context)
        {
            _context = context;
        }

        // GET: api/BodyTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BodyType>>> GetBodyType()
        {
            return await _context.BodyType.ToListAsync();
        }

        // GET: api/BodyTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BodyType>> GetBodyType(int id)
        {
            var bodyType = await _context.BodyType.FindAsync(id);

            if (bodyType == null)
            {
                return NotFound();
            }

            return bodyType;
        }

        // PUT: api/BodyTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBodyType(int id, BodyType bodyType)
        {
            if (id != bodyType.BodyTypeId)
            {
                return BadRequest();
            }

            _context.Entry(bodyType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BodyTypeExists(id))
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

        // POST: api/BodyTypes
        [HttpPost]
        public async Task<ActionResult<BodyType>> PostBodyType(BodyType bodyType)
        {
            _context.BodyType.Add(bodyType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBodyType", new { id = bodyType.BodyTypeId }, bodyType);
        }

        // DELETE: api/BodyTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BodyType>> DeleteBodyType(int id)
        {
            var bodyType = await _context.BodyType.FindAsync(id);
            if (bodyType == null)
            {
                return NotFound();
            }

            _context.BodyType.Remove(bodyType);
            await _context.SaveChangesAsync();

            return bodyType;
        }

        private bool BodyTypeExists(int id)
        {
            return _context.BodyType.Any(e => e.BodyTypeId == id);
        }
    }
}
