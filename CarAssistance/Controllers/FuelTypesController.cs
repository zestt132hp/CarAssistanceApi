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
                return NotFound();
            }

            var dto = _mapper.Map<FuelTypeDto>(fuelType);

            return dto;
        }

        // PUT: api/FuelTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFuelType(int id, string fuelTypeEntity)
        {
            if (string.IsNullOrWhiteSpace(fuelTypeEntity))
            {
                return BadRequest("Can't update empty model");
            }

            var deserializeObject = JsonConvert.DeserializeObject<FuelTypeDto>(fuelTypeEntity);
            var fuelTypeDto = _mapper.Map<Fuel>(deserializeObject);
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

            return NoContent();
        }

        // POST: api/FuelTypes
        [HttpPost]
        public async Task<ActionResult<FuelTypeDto>> PostFuelType(string fuelTypeEntity)
        {
            if (string.IsNullOrWhiteSpace(fuelTypeEntity)) 
            {
                return BadRequest("Can't Add empty model");
            }
            var fuelTypeDto = JsonConvert.DeserializeObject<Fuel>(fuelTypeEntity);
            if (fuelTypeDto == null) 
            {
                return BadRequest("Error deserialize input object");
            }

            await _repository.AddAsync(_mapper.Map<Fuel>(fuelTypeDto)).ConfigureAwait(false);
            await _unitOfWork.CommitAsync().ConfigureAwait(false);

            return CreatedAtAction("GetFuelType", new { id = fuelTypeDto.Id }, fuelTypeDto);
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
