using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROJECT.Data;
using PROJECT.DTOs;

namespace PROJECT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WaterUsageController : ControllerBase
    {
        private readonly AppDbContext _context;

        public WaterUsageController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WaterUsage>>> get_water()
        {
            return await _context.WaterUsages.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<WaterUsage>> create_water(WaterUsageDTO dto)
        {
            var water = new WaterUsage
            {
                appliance_id = dto.appliance_id,
                date = dto.date,
                liters_consumed = dto.liters_consumed,
                cycle_count = dto.cycle_count,
                cost_estimated = dto.cost_estimate
            };

            _context.WaterUsages.Add(water);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(get_water), new { id = water.appliance_id }, water);
        }
    }
}