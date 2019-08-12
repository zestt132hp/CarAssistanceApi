using System.Collections.Generic;
using System.Linq;
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
    public class CarsController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;

        private readonly string[] _includeProperty = new[]
        {
            nameof(Car.BodyType), nameof(Car.Characteristics), nameof(Car.Engine), nameof(Car.GearBox),
            nameof(Car.Manufacter), nameof(Car.Model), nameof(Car.Tires)
        };
        private readonly IMapper _mapper;
        public CarsController(IConfiguration conf, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = new UnitOfWork(conf);
        }

        // GET: api/Cars
        [HttpGet]
        public IEnumerable<CarDto> GetCar()
        {
            var cars = _mapper.Map<IEnumerable<CarDto>>(_unitOfWork.CarsRepos.Get(null, null,
                _includeProperty.Aggregate((x, y)=> $"{x}, {y}")));
            return cars;
        }

        // GET: api/Cars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarDto>> GetCar(int id)
        {
            var car = await _unitOfWork.CarsRepos.GetById(id, includeProperty: _includeProperty);
            if (car == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<CarDto>(car);
            return result;
        }

        // PUT: api/Cars/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCar(int id, CarDto car)
        {
            var tmp = await _unitOfWork.CarsRepos.GetById(id, _includeProperty);
            if (tmp == null)
            {
                return BadRequest();
            }

            var result = _mapper.Map<Car>(car);
            _unitOfWork.CarsRepos.Update(result);

            try
            {
                _unitOfWork.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExists(id))
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

        // POST: api/Cars
        [HttpPost]
        public async Task<ActionResult<CarDto>> PostCar(CarDto car)
        {
            var carUnit = _mapper.Map<Car>(car);
            if (carUnit != null)

             await  Task.Run(()=> _unitOfWork.CarsRepos.Insert(carUnit));
            _unitOfWork.Save();

            return CreatedAtAction("GetCar", new {id = carUnit?.CarId}, car);
        }

        // DELETE: api/Cars/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Car>> DeleteCar(int id)
        {
            var car = await _unitOfWork.CarsRepos.GetById(id);
            if (car == null)
            {
                return NotFound();
            }

            _unitOfWork.CarsRepos.Delete(car);
            _unitOfWork.Save();

            return car;
        }

        private bool CarExists(int id)
        {
            var car = _unitOfWork.CarsRepos.GetById(id);
            return car != null;
        }
    }
}
