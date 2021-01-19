using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarAssistance.Models;
using AutoMapper;
using CarAssistance.Data.Repository;
using Shared.Contracts.DtoModels;
using CarAssistance.Data.IRepos;
using CarAssistance.Extensions.StringExtensions;
using CarAssistance.Exceptions;

namespace CarAssistance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BodyTypesController : ControllerBases
    {        
        private readonly IUnitOfWork _UoW;
        private readonly IMapper _mapper;
        private readonly IBodyTypeRepo _repository;

        public BodyTypesController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _UoW = unitOfWork;
            _mapper = mapper;
            _repository = unitOfWork?.BodyTypeRepository;
        }

        // GET: api/BodyTypes
        [HttpGet]
        public IEnumerable<BodyTypeDto> GetBodyType()
        {
            var bodyTypes = _repository.GetAll();
            var bTypesDto = _mapper.Map<BodyTypeDto[]>(bodyTypes);
            return bTypesDto;
        }

        // GET: api/BodyTypes/5
        [HttpGet("{id}")]
        public ActionResult<BodyTypeDto> GetBodyType(int id)
        {
            var bodyType = _repository.GetById(id);
            if (bodyType == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<BodyTypeDto>(bodyType);

            return Ok(result);
        }

        // PUT: api/BodyTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBodyType(int id, string bodyTypeDto)
        {
            var dto = bodyTypeDto.GetDto<BodyTypeDto>();

            if(dto == null)
            {
                return BadRequest(ExceptionMessageHeaders.CanNotRecognizeInputModel);
            }

            if (!BodyTypeExists(id))
            {
                return NotFound(ExceptionMessageHeaders.GetMessage(ExceptionMessageHeaders.CanNotFoundEntityWithId, id));
            }

            var bodyType = _mapper.Map<BodyType>(dto);
            bodyType.Id = id;

            await _repository.UpdateAsync(bodyType).ConfigureAwait(false);
            await _UoW.CommitAsync().ConfigureAwait(false);
            
            return Ok();
        }

        // POST: api/BodyTypes
        [HttpPost]
        public async Task<IActionResult> PostBodyType(string bodyType)
        {
            var dto = bodyType.GetDto<BodyTypeDto>();

            if(dto == null)
            {
                return BadRequest(ExceptionMessageHeaders.CanNotRecognizeInputModel);
            }

            var body = _mapper.Map<BodyType>(dto);
            await _repository.AddAsync(body).ConfigureAwait(false);
            await _UoW.CommitAsync().ConfigureAwait(false);

            return Ok(body);
        }

        // DELETE: api/BodyTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBodyType(int id)
        {
            var bodyType = 
                await Task.Run(() => _repository.GetById(id)).ConfigureAwait(false);
            if (bodyType == null)
            {
                return NotFound();
            }
            _repository.Remove(bodyType);
            await _UoW.CommitAsync().ConfigureAwait(false);

            return Ok();
        }

        private bool BodyTypeExists(int id)
        {
            if (_repository.GetById(id) != null)
                return true;
            return false;
        }
    }
}
