using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarAssistance.Data;
using CarAssistance.Models;
using Microsoft.Extensions.Configuration;
using CarAssistance.Data.Repository;

namespace CarAssistance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuelTypesController : ControllerBases
    {
        private readonly IUnitOfWork _unitOfWork;

        public FuelTypesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/FuelTypes
        [HttpGet]
        public ActionResult<IEnumerable<Fuel>> GetFuelType()
        {
            var fuelDto = _unitOfWork.FuelTypeRepository.GetByExpression();
            return fuelDto.ToList();
        }

        // GET: api/FuelTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fuel>> GetFuelType(int id)
        {
            var fuelType = _unitOfWork.FuelTypeRepository.GetById(id);

            if (fuelType == null)
            {
                return NotFound();
            }

            return fuelType;
        }

        // PUT: api/FuelTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFuelType(int id, Fuel fuelType)
        {
            if (fuelType == null)
            {
                throw new NullReferenceException(nameof(fuelType));
            }
            if (id != fuelType.Id)
            {
                return BadRequest();
            }
            _unitOfWork.FuelTypeRepository.Update(fuelType);
            try
            {
                _unitOfWork.Commit();
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
        public async Task<ActionResult<Fuel>> PostFuelType(Fuel fuelType)
        {
            _unitOfWork.FuelTypeRepository.Add(fuelType);
            
            _unitOfWork.Commit();

            return CreatedAtAction("GetFuelType", new { id = fuelType?.Id }, fuelType);
        }

        // DELETE: api/FuelTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Fuel>> DeleteFuelType(int id)
        {
            var fuelType = _unitOfWork.FuelTypeRepository.GetById(id);
            if (fuelType == null)
            {
                return NotFound();
            }

            _unitOfWork.FuelTypeRepository.Remove(fuelType);
            _unitOfWork.Commit();

            return fuelType;
        }

        private bool FuelTypeExists(int id)
        {
            return _unitOfWork.FuelTypeRepository.GetById(id) != null;
        }
    }
}
