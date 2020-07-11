using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarAssistance.Models;
using CarAssistance.Models.DTO;
using AutoMapper;
using CarAssistance.Data.Repository;

namespace CarAssistance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BodyTypesController : ControllerBases
    {        
        private IUnitOfWork _UoW;
        private readonly IMapper _mapper;

        public BodyTypesController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _UoW = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/BodyTypes
        [HttpGet]
        public IEnumerable<BodyTypeDto> GetBodyType()
        {
            var bodyTypes = _UoW.BodyTypeRepository.GetAll();
            var bTypesDto = _mapper.Map<BodyTypeDto[]>(bodyTypes);
            return bTypesDto;
        }

        // GET: api/BodyTypes/5
        [HttpGet("{id}")]
        public ActionResult<BodyTypeDto> GetBodyType(int id)
        {
            var bodyType = _UoW.BodyTypeRepository.GetById(id);
            if (bodyType == null)
            {
                return NotFound();
            }

            return _mapper.Map<BodyTypeDto>(bodyType);
        }

        // PUT: api/BodyTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBodyType(int id, BodyTypeDto bodyTypeDto)
        {
            var bodyType = _mapper.Map<BodyType>(bodyTypeDto);
            bodyType.Id = id;
            await _UoW.BodyTypeRepository.UpdateAsync(bodyType).ConfigureAwait(false);

            try
            {
                await _UoW.CommitAsync().ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BodyTypeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok();
        }

        // POST: api/BodyTypes
        [HttpPost]
        public async Task<ActionResult<BodyTypeDto>> PostBodyType(BodyTypeDto bodyType)
        {
            var body = _mapper.Map<BodyType>(bodyType);
            _UoW.BodyTypeRepository.Add(body);
            await _UoW.CommitAsync().ConfigureAwait(false);
            return CreatedAtAction("GetBodyType", new { id = body.Id }, bodyType);
        }

        // DELETE: api/BodyTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BodyType>> DeleteBodyType(int id)
        {
            var bodyType = 
                await Task.Run(() => _UoW.BodyTypeRepository.GetById(id)).ConfigureAwait(false);
            if (bodyType == null)
            {
                return NotFound();
            }
            _UoW.BodyTypeRepository.Remove(bodyType);
            await _UoW.CommitAsync().ConfigureAwait(false);
            return bodyType;
        }

        private bool BodyTypeExists(int id)
        {
            if (_UoW.BodyTypeRepository.GetById(id) != null)
                return true;
            return false;
        }
    }
}
