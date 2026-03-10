using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROJECT.Data;
using PROJECT.DTOs;

namespace PROJECT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> get_users()
        {
            return await _context.Users.ToListAsync();
        }

        [HttpGet("id/{id:int}")]
        public async Task<ActionResult<User>> get_user(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpGet("email/{email}")]
        public async Task<ActionResult<User>> get_user_by_email(string email)
        {
            var user = await _context.Users
                .Where(u => u.email == email)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPost]
        public async Task<ActionResult<User>> create_user(CreateUserDTO dto)
        {
            var user = new User
            {
                name = dto.name,
                email = dto.email,
                password_hash = dto.password_hash
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(get_user), new { id = user.user_id }, user);
        }

        [HttpDelete("id/{id:int}")]
        public async Task<ActionResult> delete_user(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}