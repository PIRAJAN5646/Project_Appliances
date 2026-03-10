using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROJECT.Data;
using PROJECT.DTOs;

namespace PROJECT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly AppDbContext _context;

        public NotificationController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Notification>>> get_notifications()
        {
            return await _context.Notifications.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Notification>> create_notification(NotificationDTO dto)
        {
            var notification = new Notification
            {
                user_id = dto.user_id,
                alert_id = dto.alert_id,
                channel = dto.channel
            };

            _context.Notifications.Add(notification);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(get_notifications), new { id = notification.alert_id }, notification);
        }
    }
}