using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarAssistance.Data;
using CarAssistance.Models;
using Microsoft.Extensions.Configuration;
using CarAssistance.Models.DTO;
using AutoMapper;

namespace CarAssistance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BodyTypesController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public BodyTypesController(IConfiguration config, IMapper mapper)
        {
            _unitOfWork = new UnitOfWork(config);
            _mapper = mapper;
        }

        // GET: api/BodyTypes
        [HttpGet]
        public IEnumerable<BodyTypeDto> GetBodyType()
        {
            var bodyTypes = _unitOfWork.BodyTypesRepos.Get();
            var bTypesDto = _mapper.Map<BodyTypeDto[]>(bodyTypes);
            return bTypesDto;
        }
        
        // GET: api/BodyTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BodyTypeDto>> GetBodyType(int id)
        {
            var bodyType = await _unitOfWork.BodyTypesRepos.GetById(id);
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
            _unitOfWork.BodyTypesRepos.Update(bodyType);

            try
            {
                await Task.Run(() => _unitOfWork.Save());
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

            return NoContent();
        }

        // POST: api/BodyTypes
        [HttpPost]
        public async Task<ActionResult<BodyTypeDto>> PostBodyType(BodyTypeDto bodyType)
        {
            var body = _mapper.Map<BodyType>(bodyType);
            _unitOfWork.BodyTypesRepos.Insert(body);
            await Task.Run(()=>_unitOfWork.Save());

            return CreatedAtAction("GetBodyType", new { id = body.BodyTypeId }, bodyType);
        }

        // DELETE: api/BodyTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BodyType>> DeleteBodyType(int id)
        {
            var bodyType = await Task.Run(()=>_unitOfWork.BodyTypesRepos.GetById(id));
            if (bodyType == null)
            {
                return NotFound();
            }
            _unitOfWork.BodyTypesRepos.Delete(bodyType);
            await Task.Run(() => _unitOfWork.Save());

            return bodyType;
        }

        private bool BodyTypeExists(int id)
        {
            if (_unitOfWork.BodyTypesRepos.GetById(id).Result != null)
                return true;
            return false;
        }
    }
}
