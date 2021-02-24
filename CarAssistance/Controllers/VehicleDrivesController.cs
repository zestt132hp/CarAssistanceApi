using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarAssistance.Data;
using CarAssistance.Models;

namespace CarAssistance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleDrivesController : ControllerBases
    {
        private readonly NpgSqlDataContext _context;

        public VehicleDrivesController(NpgSqlDataContext context)
        {
            _context = context;
        }

        // GET: api/VehicleDrives
        [HttpGet, Route("vehicleDrivers")]
        public async Task<ActionResult<IEnumerable<VehicleDrive>>> GetVehicleDrive()
        {
            return await _context.VehicleDrive.ToListAsync();
        }

        // GET: api/VehicleDrives/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleDrive>> GetVehicleDrive(int id)
        {
            var vehicleDrive = await _context.VehicleDrive.FindAsync(id);

            if (vehicleDrive == null)
            {
                return NotFound();
            }

            return vehicleDrive;
        }

        // PUT: api/VehicleDrives/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehicleDrive(int id, VehicleDrive vehicleDrive)
        {
            if (id != vehicleDrive?.Id)
            {
                return BadRequest();
            }

            _context.Entry(vehicleDrive).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleDriveExists(id))
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

        // POST: api/VehicleDrives
        [HttpPost]
        public async Task<ActionResult<VehicleDrive>> PostVehicleDrive(VehicleDrive vehicleDrive)
        {
            _context.VehicleDrive.Add(vehicleDrive);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVehicleDrive", new { id = vehicleDrive?.Id }, vehicleDrive);
        }

        // DELETE: api/VehicleDrives/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<VehicleDrive>> DeleteVehicleDrive(int id)
        {
            var vehicleDrive = await _context.VehicleDrive.FindAsync(id);
            if (vehicleDrive == null)
            {
                return NotFound();
            }

            _context.VehicleDrive.Remove(vehicleDrive);
            await _context.SaveChangesAsync();

            return vehicleDrive;
        }

        private bool VehicleDriveExists(int id)
        {
            return _context.VehicleDrive.Any(e => e.Id == id);
        }
    }
}
