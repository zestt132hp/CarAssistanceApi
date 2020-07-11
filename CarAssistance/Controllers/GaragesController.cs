using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarAssistance.Data;
using CarAssistance.Models;
using CarAssistance.Models.DTO;
using Microsoft.Extensions.Configuration;
using CarAssistance.Data.Repository;

namespace CarAssistance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GaragesController : ControllerBases
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public GaragesController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Garages
        [HttpGet]
        public IEnumerable<GarageDto> GetGarage()
        {
            var allGarages = _unitOfWork.GarageRepos.GetByExpression(null, null,
                new[] {nameof(Garage.Car), nameof(Garage.User)}.Aggregate(
                    (x, y) => $"{x}, {y}"));
            var garagesDto = _mapper.Map<IEnumerable<GarageDto>>(allGarages);
            return garagesDto;
        }

        // GET: api/Garages/5
        [HttpGet("{id}")]
        public ActionResult<GarageDto> GetGarage(int id)
        {
            var garage = _unitOfWork.GarageRepos.GetById(id);
        if (garage == null)
            {
                return NotFound();
            }
            return _mapper.Map<GarageDto>(garage);
        }

        // PUT: api/Garages/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGarage(int id, GarageDto garage)
        {
            var garageObj = _mapper.Map<Garage>(garage);
            var garageDb = await _unitOfWork.GarageRepos.GetByIdAsync(id).ConfigureAwait(false);
            if (garageDb == null)
            {
                return BadRequest();
            }

            garageDb = garageObj;
            garageDb.GarageId = id;
            _unitOfWork.GarageRepos.Update(garageDb);
            try
            {
                await _unitOfWork.CommitAsync().ConfigureAwait(false);
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
        public async Task<ActionResult<GarageDto>> PostGarage(GarageDto garage)
        {
            var dto = _mapper.Map<Garage>(garage);
            await Task.Run(()=>_unitOfWork.GarageRepos.AddAsync(dto)).ConfigureAwait(false);
            await _unitOfWork.CommitAsync().ConfigureAwait(false);

            return CreatedAtAction("GetGarage", new { id = dto.GarageId }, garage);
        }

        // DELETE: api/Garages/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Garage>> DeleteGarage(int id)
        {
            var garage = await _unitOfWork.GarageRepos.GetByIdAsync(id).ConfigureAwait(false);
            if (garage == null)
            {
                return NotFound();
            }
            await _unitOfWork.GarageRepos.RemoveAsync(garage).ConfigureAwait(false);
            await _unitOfWork.CommitAsync().ConfigureAwait(false);

            return garage;
        }

        private bool GarageExists(int id)
        {
            return _unitOfWork.GarageRepos.GetById(id) != null;
        }
    }
}
