using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROJECT.Data;
using PROJECT.DTOs;

namespace PROJECT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensorDataController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SensorDataController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SensorData>>> get_sensor_data()
        {
            return await _context.SensorData.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<SensorData>> create_sensor(SensorDataDTO dto)
        {
            var sensor = new SensorData
            {
                appliance_id = dto.appliance_id,
                reading_type = dto.reading_type,
                value = dto.value,
                unit = dto.unit
            };

            _context.SensorData.Add(sensor);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(get_sensor_data), new { id = sensor.appliance_id }, sensor);
        }
    }
}