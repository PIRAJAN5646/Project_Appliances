using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROJECT.Data;
using PROJECT.DTOs;

namespace PROJECT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplianceController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ApplianceController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Appliance>>> get_appliances()
        {
            return await _context.Appliances.ToListAsync();
        }

        [HttpGet("id/{id:int}")]
        public async Task<ActionResult<Appliance>> get_appliance(int id)
        {
            var appliance = await _context.Appliances.FindAsync(id);

            if (appliance == null)
                return NotFound();

            return appliance;
        }

        [HttpPost]
        public async Task<ActionResult<Appliance>> create_appliance(CreateApplianceDTO dto)
        {
            var appliance = new Appliance
            {
                home_id = dto.home_id,
                type_id = dto.type_id,
                name = dto.name,
                model = dto.model,
                status="Active",
                device_identifier = dto.device_identifier
            };

            _context.Appliances.Add(appliance);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(get_appliance), new { id = appliance.appliance_id }, appliance);
        }

        [HttpDelete("id/{id:int}")]
        public async Task<ActionResult> delete_appliance(int id)
        {
            var appliance = await _context.Appliances.FindAsync(id);

            if (appliance == null)
                return NotFound();

            _context.Appliances.Remove(appliance);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}