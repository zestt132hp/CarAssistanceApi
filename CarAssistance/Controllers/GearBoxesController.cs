using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarAssistance.Models;
using CarAssistance.Data.Repository;
using System;

namespace CarAssistance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GearBoxesController : ControllerBases
    {
        private readonly IUnitOfWork _unitOfWork;

        public GearBoxesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/GearBoxes
        [HttpGet, Route("gearboxes")]
        public IEnumerable<GearBoxes> GetGearBox()
        {
            return _unitOfWork.GearBoxRepo.GetByExpression();
        }

        // GET: api/GearBoxes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GearBoxes>> GetGearBox(int id)
        {
            var gearBox = await _unitOfWork.GearBoxRepo.GetByIdAsync(id).ConfigureAwait(false);
            if (gearBox == null)
            {
                return NotFound();
            }

            return gearBox;
        }

        // PUT: api/GearBoxes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGearBox(int id, [FromBody] GearBoxes gearBox)
        {
            if (id != gearBox?.Id)
            {
                return BadRequest();
            }
            await _unitOfWork.GearBoxRepo.UpdateAsync(gearBox).ConfigureAwait(false);

            try
            {
                _unitOfWork.Commit();
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
        public async Task<ActionResult<GearBoxes>> PostGearBox([FromBody] GearBoxes gearBox)
        {
            try
            {
                await _unitOfWork.GearBoxRepo.AddAsync(gearBox).ConfigureAwait(false);

                _unitOfWork.Commit();

                return Ok();
            }

            catch (Exception e)
            {
                return BadRequest();
            }
        }

        // DELETE: api/GearBoxes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GearBoxes>> DeleteGearBox(int id)
        {
            var gearBox = await _unitOfWork.GearBoxRepo.GetByIdAsync(id).ConfigureAwait(false);
            if (gearBox == null)
            {
                return NotFound();
            }

            await _unitOfWork.GearBoxRepo.RemoveAsync(gearBox).ConfigureAwait(false);
            _unitOfWork.Commit();

            return gearBox;
        }

        private bool GearBoxExists(int id)
        {
            return _unitOfWork.GearBoxRepo.GetById(id) != null;
        }
    }
}
