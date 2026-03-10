using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROJECT.Data;
using PROJECT.DTOs;

namespace PROJECT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplianceTypeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ApplianceTypeController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApplianceType>>> get_types()
        {
            return await _context.ApplianceTypes.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<ApplianceType>> create_type(CreateApplianceTypeDTO dto)
        {
            var type = new ApplianceType
            {
                name = dto.name,
                category = dto.category,
                avg_energy_rating = dto.avg_energy_rating,
                avg_water_rating = dto.avg_water_rating
            };

            _context.ApplianceTypes.Add(type);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(get_types), new { id = type.type_id }, type);
        }
    }
}