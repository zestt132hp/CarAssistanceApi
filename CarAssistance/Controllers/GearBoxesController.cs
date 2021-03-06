﻿using System.Collections.Generic;
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
        [HttpGet]
        public IEnumerable<GearBox> GetGearBox()
        {
            return _unitOfWork.GearBoxRepo.GetByExpression();
        }

        // GET: api/GearBoxes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GearBox>> GetGearBox(int id)
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
        public async Task<IActionResult> PutGearBox(int id, [FromBody] GearBox gearBox)
        {
            if (id != gearBox?.GearBoxId)
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
        public async Task<ActionResult<GearBox>> PostGearBox([FromBody] GearBox gearBox)
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
        public async Task<ActionResult<GearBox>> DeleteGearBox(int id)
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
