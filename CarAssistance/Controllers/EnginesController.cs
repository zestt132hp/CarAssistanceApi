using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarAssistance.Models;
using CarAssistance.Data.Repository;
using Shared.Contracts.DtoModels;
using CarAssistance.Data.IRepos;
using System;
using CarAssistance.Exceptions;
using CarAssistance.Extensions.StringExtensions;

namespace CarAssistance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnginesController : ControllerBases
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEngineRepo _repository;
        public EnginesController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;

            if (unitOfWork == null) 
            {
                throw new NullReferenceException(nameof(unitOfWork));
            }

            _repository = unitOfWork.EngineRepository;
        }

        // GET: api/Engines
        [HttpGet]
        public async Task<IEnumerable<EngineDto>> GetEngine()
        {
            var engines = await _repository.GetAllAsync().ConfigureAwait(false);
            var engineDtos = _mapper.Map<EngineDto[]>(engines);
            return engineDtos;
        }

        // GET: api/Engines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EngineDto>> GetEngine(int id)
        {
            var engine = await _repository.GetByIdAsync(id).ConfigureAwait(false);
            if (engine == null)
            {
                return NotFound();
            }

            var engineDto = _mapper.Map<EngineDto>(engine);
            return engineDto;
        }

        // PUT: api/Engines/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEngine(int id, string engineDto)
        {
            var engineUnit = await _repository.GetByIdAsync(id).ConfigureAwait(false);
            var engineDtoDes = engineDto.GetDto<EngineDto>();

            if (engineUnit == null) 
            {
                return NotFound(ExceptionMessageHeaders.GetMessage(ExceptionMessageHeaders.CanNotFoundEntityWithId, id));
            }

            if (engineDto == null) 
            {
                return BadRequest(ExceptionMessageHeaders.CanNotRecognizeInputModel);
            }
            
            engineUnit = _mapper.Map<Engine>(engineDtoDes);
            engineUnit.Id = id;

            _repository.Update(engineUnit);

            try
            {
               await  _unitOfWork.CommitAsync().ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EngineExists(id))
                {
                    return NotFound(ExceptionMessageHeaders.GetMessage(ExceptionMessageHeaders.CanNotFoundEntityWithId, id));
                }
                else
                {
                    throw;
                }
            }

            return Ok(engineDtoDes);
        }

        // POST: api/Engines
        [HttpPost]
        public async Task<ActionResult<EngineDto>> PostEngine(string engineDto)
        {
            var engineDtoDes = engineDto.GetDto<EngineDto>();
            if (engineDtoDes == null) 
            {
                return BadRequest(ExceptionMessageHeaders.CanNotRecognizeInputModel);
            }

            var unit = _mapper.Map<Engine>(engineDtoDes);

            await _repository.AddAsync(unit).ConfigureAwait(false);
            await _unitOfWork.CommitAsync().ConfigureAwait(false);

            return engineDtoDes;
        }

        // DELETE: api/Engines/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EngineDto>> DeleteEngine(int id)
        {
            var engine = await _repository.GetByIdAsync(id).ConfigureAwait(false);
            if (engine == null)
            {
                return NotFound();
            }

            await _repository.RemoveAsync(engine).ConfigureAwait(false);
            await _unitOfWork.CommitAsync().ConfigureAwait(false);

            var result = _mapper.Map<EngineDto>(engine);

            return result;
        }

        private bool EngineExists(int id)
        {
            return _repository.GetById(id) != null;
        }
    }
}
