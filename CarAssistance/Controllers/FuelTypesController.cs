using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarAssistance.Data;
using CarAssistance.Models;
using Microsoft.Extensions.Configuration;

namespace CarAssistance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuelTypesController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;

        public FuelTypesController(IConfiguration config)
        {
            _unitOfWork = new UnitOfWork(config);
        }

        // GET: api/FuelTypes
        [HttpGet]
        public ActionResult<IEnumerable<FuelType>> GetFuelType()
        {
            var fuelDto = _unitOfWork.FuelTypeRepos.Get();
            return fuelDto.ToList();
        }

        // GET: api/FuelTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FuelType>> GetFuelType(int id)
        {
            var fuelType = await _unitOfWork.FuelTypeRepos.GetById(id);

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
            _unitOfWork.FuelTypeRepos.Update(fuelType);
            try
            {
                await Task.Run(() => _unitOfWork.Save());
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
            _unitOfWork.FuelTypeRepos.Insert(fuelType);
            
            await Task.Run(()=> _unitOfWork.Save());

            return CreatedAtAction("GetFuelType", new { id = fuelType.FuelTypeId }, fuelType);
        }

        // DELETE: api/FuelTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FuelType>> DeleteFuelType(int id)
        {
            var fuelType = await _unitOfWork.FuelTypeRepos.GetById(id);
            if (fuelType == null)
            {
                return NotFound();
            }

            _unitOfWork.FuelTypeRepos.Delete(fuelType);
            await Task.Run(()=>_unitOfWork.Save());

            return fuelType;
        }

        private bool FuelTypeExists(int id)
        {
            return _unitOfWork.FuelTypeRepos.GetById(id) != null;
        }
    }
}
