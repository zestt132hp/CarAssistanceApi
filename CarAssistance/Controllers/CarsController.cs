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
    public class CarsController : ControllerBases
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICarRepo _repository;        
        private readonly IMapper _mapper;

        [Obsolete("Пример использование запроса по полям в БД")]
        private readonly string[] _includeProperty = new[]
        {
            nameof(Car.BodyType), nameof(Car.Characteristics), nameof(Car.Engine), nameof(Car.GearBox),
            nameof(Car.Manufacter), nameof(Car.Model), nameof(Car.Tires)
        };
        public CarsController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;

            if (unitOfWork == null) 
            {
                throw new NullReferenceException(nameof(unitOfWork));
            }
            _repository = unitOfWork.CarRepository;
        }

        // GET: api/Cars
        [HttpGet, Route("cars")]
        public async Task<ActionResult<IEnumerable<CarDto>>> GetCar()
        {
            var cars = await _repository.GetAllAsync().ConfigureAwait(false);

            if (cars == null) 
            {
                return NotFound();
            }

            var result = _mapper.Map<CarDto[]>(cars);

            return result;
        }

        // GET: api/Cars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarDto>> GetCar(int id)
        {
            var car = await _repository.GetByIdAsync(id).ConfigureAwait(false);
            if (car == null)
            {
                return NotFound(
                    ExceptionMessageHeaders.GetMessage(ExceptionMessageHeaders.CanNotFoundEntityWithId, id)
                    );
            }

            var result = _mapper.Map<CarDto>(car);
            return result;
        }

        // PUT: api/Cars/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCar(int id, string carDto)
        {
            var tmp = _repository.GetById(id);
            if (tmp == null || string.IsNullOrWhiteSpace(carDto))
            {
                return NotFound(ExceptionMessageHeaders.GetMessage(ExceptionMessageHeaders.CanNotFoundEntityWithId, id));
            }

            var car = carDto.GetDto<CarDto>();
            if (car == null) 
            {
                return BadRequest(ExceptionMessageHeaders.CanNotRecognizeInputModel);
            }

            var result = _mapper.Map<Car>(car);
            _repository.Update(result);

            try
            {
                await _unitOfWork.CommitAsync().ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExists(id))
                {
                    return NotFound();
                }
                else
                {
                    BadRequest();
                }
            }

            return Ok(result);
        }

        // POST: api/Cars
        [HttpPost]
        public async Task<ActionResult<CarDto>> PostCar(string carDto)
        {
            var dto = carDto.GetDto<CarDto>();

            if (dto == null) 
            {
                BadRequest(ExceptionMessageHeaders.CanNotRecognizeInputModel);
            }

            var entity = _mapper.Map<Car>(dto);
            await _repository.AddAsync(entity).ConfigureAwait(false);
            await _unitOfWork.CommitAsync().ConfigureAwait(false);

            return CreatedAtAction("GetCar", new {id = entity?.Id}, dto);
        }

        // DELETE: api/Cars/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Car>> DeleteCar(int id)
        {
            var car = _repository.GetById(id);
            if (car == null)
            {
                return NotFound(ExceptionMessageHeaders.GetMessage(ExceptionMessageHeaders.CanNotFoundEntityWithId, id));
            }

            await _repository.RemoveAsync(car).ConfigureAwait(false);
            await _unitOfWork.CommitAsync().ConfigureAwait(false);

            return car;
        }

        private bool CarExists(int id)
        {
            var car = _repository.GetById(id);
            return car != null;
        }
    }
}
