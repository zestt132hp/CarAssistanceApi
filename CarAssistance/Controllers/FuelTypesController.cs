using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarAssistance.Models;
using CarAssistance.Data.Repository;
using AutoMapper;
using CarAssistance.Data.IRepos;
using Newtonsoft.Json;
using Shared.Contracts.DtoModels;
using CarAssistance.Exceptions;
using CarAssistance.Extensions.StringExtensions;

namespace CarAssistance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuelTypesController : ControllerBases
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IFuelTypeRepo _repository;

        public FuelTypesController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;

            if (unitOfWork == null) 
            {
                throw new NullReferenceException(nameof(unitOfWork));
            }

            _repository = unitOfWork.FuelTypeRepository;
        }

        // GET: api/FuelTypes
        [HttpGet]
        public IEnumerable<FuelTypeDto> GetFuelType()
        {
            var entity = _repository.GetAll();
            var fuelsDto = _mapper.Map<FuelTypeDto[]>(entity);

            return fuelsDto;
        }

        // GET: api/FuelTypes/5
        [HttpGet("{id}")]
        public ActionResult<FuelTypeDto> GetFuelType(int id)
        {
            var fuelType = _repository.GetById(id);

            if (fuelType == null)
            {
                return NotFound(ExceptionMessageHeaders.GetMessage(ExceptionMessageHeaders.GetMessage(ExceptionMessageHeaders.CanNotFoundEntityWithId, id)));
            }

            var dto = _mapper.Map<FuelTypeDto>(fuelType);

            return dto;
        }

        // PUT: api/FuelTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFuelType(int id, string fuelTypeEntity)
        {
            var dto = fuelTypeEntity.GetDto<FuelTypeDto>();
            if (string.IsNullOrWhiteSpace(fuelTypeEntity)|| dto == null)
            {
                return BadRequest(ExceptionMessageHeaders.CanNotRecognizeInputModel);
            }

            var fuelTypeDto = _mapper.Map<Fuel>(dto);
            fuelTypeDto.Id = id;

            _repository.Update(fuelTypeDto);
            try
            {
                await _unitOfWork.CommitAsync().ConfigureAwait(false);
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

            return Ok(); 
        }

        // POST: api/FuelTypes
        [HttpPost]
        public async Task<ActionResult<FuelTypeDto>> PostFuelType(string fuelTypeEntity)
        {
            var dto = fuelTypeEntity.GetDto<FuelTypeDto>();
            if (string.IsNullOrWhiteSpace(fuelTypeEntity) || dto == null) 
            {
                return BadRequest(ExceptionMessageHeaders.CanNotRecognizeInputModel);
            }

            await _repository.AddAsync(_mapper.Map<Fuel>(dto)).ConfigureAwait(false);
            await _unitOfWork.CommitAsync().ConfigureAwait(false);

            return CreatedAtAction("GetFuelType", dto);
        }

        // DELETE: api/FuelTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteFuelType(int id)
        {
            var fuelType = _repository.GetById(id);
            if (fuelType == null)
            {
                return NotFound();
            }

            await _repository.RemoveAsync(fuelType).ConfigureAwait(false);
            await _unitOfWork.CommitAsync().ConfigureAwait(false);

            return Ok();
        }

        private bool FuelTypeExists(int id)
        {
            return _repository.GetById(id) != null;
        }
    }
}
