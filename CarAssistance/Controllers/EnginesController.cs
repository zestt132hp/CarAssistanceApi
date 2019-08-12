using System.Collections.Generic;
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
    public class EnginesController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public EnginesController(IConfiguration config, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = new UnitOfWork(config);
        }

        // GET: api/Engines
        [HttpGet]
        public ActionResult<IEnumerable<EngineDto>> GetEngine()
        {
            var engines =
                _mapper.Map<IEnumerable<EngineDto>>(_unitOfWork.EnginesRepos.Get(null, null, nameof(Engine.Fuel)));
            return new ActionResult<IEnumerable<EngineDto>>(engines);
        }

        // GET: api/Engines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EngineDto>> GetEngine(int id)
        {
            var engine = await _unitOfWork.EnginesRepos.GetById(id, nameof(Engine.Fuel));
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
            var engineUnit = await _unitOfWork.EnginesRepos.GetById(id);
            if (engineUnit == null)
            {
                return BadRequest();
            }

            engineUnit = _mapper.Map<Engine>(engine);
            _unitOfWork.EnginesRepos.Update(engineUnit);

            try
            {
                await Task.Run(()=> _unitOfWork.Save());
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
            _unitOfWork.EnginesRepos.Insert(unit);
            await Task.Run(()=>_unitOfWork.Save());

            return CreatedAtAction("GetEngine", new { id = unit.EngineId }, engine);
        }

        // DELETE: api/Engines/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EngineDto>> DeleteEngine(int id)
        {
            var engine = await _unitOfWork.EnginesRepos.GetById(id);
            if (engine == null)
            {
                return NotFound();
            }

            _unitOfWork.EnginesRepos.Delete(engine);
            await Task.Run(()=>_unitOfWork.Save());
            var result = _mapper.Map<EngineDto>(engine);

            return result;
        }

        private bool EngineExists(int id)
        {
            return _unitOfWork.EnginesRepos.GetById(id) != null;
        }
    }
}
