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

namespace CarAssistance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GaragesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly UnitOfWork _unitOfWork;
        public GaragesController(IConfiguration config, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = new UnitOfWork(config);
        }

        // GET: api/Garages
        [HttpGet]
        public IEnumerable<GarageDto> GetGarage()
        {
            var allGarages = _unitOfWork.GarageRepos.Get(null, null,
                new[] {nameof(Garage.Car), nameof(Garage.User)}.Aggregate(
                    (x, y) => $"{x}, {y}"));
            var garagesDto = _mapper.Map<IEnumerable<GarageDto>>(allGarages);
            return garagesDto;
        }

        // GET: api/Garages/5
        [HttpGet("{id}")]
        public ActionResult<GarageDto> GetGarage(int id)
        {
            var garage = _unitOfWork.GarageRepos.GetById(id, nameof(Garage.Car), nameof(Garage.User));
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
            var garageDb = await _unitOfWork.GarageRepos.GetById(id);
            if (garageDb == null)
            {
                return BadRequest();
            }

            garageDb = garageObj;
            garageDb.GarageId = id;
            _unitOfWork.GarageRepos.Update(garageDb);
            try
            {
                _unitOfWork.Save();
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
            await Task.Run(()=>_unitOfWork.GarageRepos.Insert(dto));
            _unitOfWork.Save();

            return CreatedAtAction("GetGarage", new { id = dto.GarageId }, garage);
        }

        // DELETE: api/Garages/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Garage>> DeleteGarage(int id)
        {
            var garage = await _unitOfWork.GarageRepos.GetById(id);
            if (garage == null)
            {
                return NotFound();
            }
            _unitOfWork.GarageRepos.Delete(id);
            _unitOfWork.Save();

            return garage;
        }

        private bool GarageExists(int id)
        {
            return _unitOfWork.GarageRepos.GetById(id) != null;
        }
    }
}
