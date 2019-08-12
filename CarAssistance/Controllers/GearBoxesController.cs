using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarAssistance.Data;
using CarAssistance.Models;
using Microsoft.Extensions.Configuration;

namespace CarAssistance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GearBoxesController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GearBoxesController(IConfiguration config, IMapper mapper)
        {
            _unitOfWork = new UnitOfWork(config);
            _mapper = mapper;
        }

        // GET: api/GearBoxes
        [HttpGet]
        public IEnumerable<GearBox> GetGearBox()
        {
            return _unitOfWork.GearsRepos.Get();
        }

        // GET: api/GearBoxes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GearBox>> GetGearBox(int id)
        {
            var gearBox = await _unitOfWork.GearsRepos.GetById(id);
            if (gearBox == null)
            {
                return NotFound();
            }

            return gearBox;
        }

        // PUT: api/GearBoxes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGearBox(int id, GearBox gearBox)
        {
            if (id != gearBox.GearBoxId)
            {
                return BadRequest();
            }
            await Task.Run(()=>_unitOfWork.GearsRepos.Update(gearBox));

            try
            {
                await Task.Run(()=>_unitOfWork.Save());
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GearBoxExists(id))
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

        // POST: api/GearBoxes
        [HttpPost]
        public async Task<ActionResult<GearBox>> PostGearBox(GearBox gearBox)
        {
            await Task.Run(() => _unitOfWork.GearsRepos.Insert(gearBox));

            _unitOfWork.Save();

            return CreatedAtAction("GetGearBox", new { id = gearBox.GearBoxId }, gearBox);
        }

        // DELETE: api/GearBoxes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GearBox>> DeleteGearBox(int id)
        {
            var gearBox = await _unitOfWork.GearsRepos.GetById(id);
            if (gearBox == null)
            {
                return NotFound();
            }

            _unitOfWork.GearsRepos.Delete(gearBox);
            await Task.Run(()=>_unitOfWork.Save());

            return gearBox;
        }

        private bool GearBoxExists(int id)
        {
            return _unitOfWork.GearsRepos.GetById(id) != null;
        }
    }
}
