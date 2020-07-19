using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarAssistance.Models;
using AutoMapper;
using CarAssistance.Data.Repository;
using Newtonsoft.Json;
using Shared.Contracts.DtoModels;

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

            var result = JsonConvert.SerializeObject(bodyType);

            return Ok(result);
        }

        // PUT: api/BodyTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBodyType(int id, string bodyTypeDto)
        {
            var deserializeObject = JsonConvert.DeserializeObject<BodyTypeDto>(bodyTypeDto);

            if(deserializeObject == null)
            {
                return BadRequest();
            }

            var bodyType = _mapper.Map<BodyType>(deserializeObject);
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
        public async Task<IActionResult> PostBodyType(string bodyType)
        {
            var deserializeResult = JsonConvert.DeserializeObject<BodyTypeDto>(bodyType);

            if(deserializeResult == null)
            {
                return BadRequest();
            }

            var body = _mapper.Map<BodyType>(deserializeResult);
            _UoW.BodyTypeRepository.Add(body);
            await _UoW.CommitAsync().ConfigureAwait(false);

            return Ok();
        }

        // DELETE: api/BodyTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBodyType(int id)
        {
            var bodyType = 
                await Task.Run(() => _UoW.BodyTypeRepository.GetById(id)).ConfigureAwait(false);
            if (bodyType == null)
            {
                return NotFound();
            }
            _UoW.BodyTypeRepository.Remove(bodyType);
            await _UoW.CommitAsync().ConfigureAwait(false);
            return Ok();
        }

        private bool BodyTypeExists(int id)
        {
            if (_UoW.BodyTypeRepository.GetById(id) != null)
                return true;
            return false;
        }
    }
}
