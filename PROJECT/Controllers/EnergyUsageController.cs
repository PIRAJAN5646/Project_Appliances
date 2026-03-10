using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROJECT.Data;
using PROJECT.DTOs;

namespace PROJECT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnergyUsageController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EnergyUsageController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnergyUsage>>> get_energy()
        {
            return await _context.EnergyUsages.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<EnergyUsage>> create_energy(EnergyUsageDTO dto)
        {
            var energy = new EnergyUsage
            {
                appliance_id = dto.appliance_id,
                date = dto.date,
                kwh_consumed = dto.kwh_consumed,
                peak_usage = dto.peak_usage,
                cost_estimated = dto.cost_estimate
            };

            _context.EnergyUsages.Add(energy);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(get_energy), new { id = energy.appliance_id }, energy);
        }
    }
}