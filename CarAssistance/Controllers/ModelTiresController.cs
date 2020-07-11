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
    public class ModelTiresController : ControllerBases
    {
        private readonly NpgSqlDataContext _context;

        public ModelTiresController(NpgSqlDataContext context)
        {
            _context = context;
        }

        // GET: api/ModelTires
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ModelTires>>> GetModelTires()
        {
            return await _context.ModelTires.ToListAsync();
        }

        // GET: api/ModelTires/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ModelTires>> GetModelTires(int id)
        {
            var modelTires = await _context.ModelTires.FindAsync(id);

            if (modelTires == null)
            {
                return NotFound();
            }

            return modelTires;
        }

        // PUT: api/ModelTires/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModelTires(int id, ModelTires modelTires)
        {
            if (id != modelTires?.Id)
            {
                return BadRequest();
            }

            _context.Entry(modelTires).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModelTiresExists(id))
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

        // POST: api/ModelTires
        [HttpPost]
        public async Task<ActionResult<ModelTires>> PostModelTires(ModelTires modelTires)
        {
            _context.ModelTires.Add(modelTires);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetModelTires", new { id = modelTires?.Id }, modelTires);
        }

        // DELETE: api/ModelTires/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ModelTires>> DeleteModelTires(int id)
        {
            var modelTires = await _context.ModelTires.FindAsync(id);
            if (modelTires == null)
            {
                return NotFound();
            }

            _context.ModelTires.Remove(modelTires);
            await _context.SaveChangesAsync();

            return modelTires;
        }

        private bool ModelTiresExists(int id)
        {
            return _context.ModelTires.Any(e => e.Id == id);
        }
    }
}
