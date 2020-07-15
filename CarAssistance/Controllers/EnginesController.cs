using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarAssistance.Models;
using CarAssistance.Models.DTO;
using CarAssistance.Data.Repository;

namespace CarAssistance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnginesController : ControllerBases
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public EnginesController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Engines
        [HttpGet]
        public ActionResult<IEnumerable<EngineDto>> GetEngine()
        {
            var engines =
                _mapper.Map<IEnumerable<EngineDto>>(_unitOfWork.EngineRepository.GetByExpression(null, null, nameof(Engine.Fuel)));
            return new ActionResult<IEnumerable<EngineDto>>(engines);
        }

        // GET: api/Engines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EngineDto>> GetEngine(int id)
        {
            var engine = _unitOfWork.EngineRepository.GetById(id);
            if (engine == null)
            {
                return NotFound();
            }

            var engineDto = _mapper.Map<EngineDto>(engine);
            return engineDto;
        }

        // PUT: api/Engines/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEngine(int id, EngineDto engine)
        {
            var engineUnit = _unitOfWork.EngineRepository.GetById(id);
            if (engineUnit == null)
            {
                return BadRequest();
            }

            engineUnit = _mapper.Map<Engine>(engine);
            _unitOfWork.EngineRepository.Update(engineUnit);

            try
            {
                _unitOfWork.Commit();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EngineExists(id))
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

        // POST: api/Engines
        [HttpPost]
        public async Task<ActionResult<EngineDto>> PostEngine(EngineDto engine)
        {
            var unit = _mapper.Map<Engine>(engine);
            _unitOfWork.EngineRepository.Add(unit);
            _unitOfWork.Commit();

            return CreatedAtAction("GetEngine", new { id = unit.Id }, engine);
        }

        // DELETE: api/Engines/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EngineDto>> DeleteEngine(int id)
        {
            var engine = _unitOfWork.EngineRepository.GetById(id);
            if (engine == null)
            {
                return NotFound();
            }

            _unitOfWork.EngineRepository.Remove(engine);
            _unitOfWork.Commit();
            var result = _mapper.Map<EngineDto>(engine);

            return result;
        }

        private bool EngineExists(int id)
        {
            return _unitOfWork.EngineRepository.GetById(id) != null;
        }
    }
}
