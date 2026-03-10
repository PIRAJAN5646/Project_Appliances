using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROJECT.Data;
using PROJECT.DTOs;

namespace PROJECT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlertController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AlertController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Alert>>> get_alerts()
        {
            return await _context.Alerts.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Alert>> create_alert(AlertsDTO dto)
        {
            var alert = new Alert
            {
                appliance_id = dto.appliance_id,
                alert_type = dto.alert_type,
                message = dto.message,
                is_resolved = dto.is_resolved,
                severity = dto.severity
            };

            _context.Alerts.Add(alert);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(get_alerts), new { id = alert.appliance_id }, alert);
        }
    }
}