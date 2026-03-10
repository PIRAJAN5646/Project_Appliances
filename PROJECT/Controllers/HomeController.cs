using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROJECT.Data;
using PROJECT.DTOs;

namespace PROJECT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Home>>> get_homes()
        {
            return await _context.Homes.ToListAsync();
        }

        [HttpGet("id/{id:int}")]
        public async Task<ActionResult<Home>> get_home(int id)
        {
            var home = await _context.Homes.FindAsync(id);

            if (home == null)
                return NotFound();

            return home;
        }

        [HttpPost]
        public async Task<ActionResult<Home>> create_home(CreateHomeDTO dto)
        {
            var home = new Home
            {
                user_id = dto.user_id,
                name = dto.name,
                address = dto.address
            };

            _context.Homes.Add(home);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(get_home), new { id = home.home_id }, home);
        }

        [HttpDelete("id/{id:int}")]
        public async Task<ActionResult> delete_home(int id)
        {
            var home = await _context.Homes.FindAsync(id);

            if (home == null)
                return NotFound();

            _context.Homes.Remove(home);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}