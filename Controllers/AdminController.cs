using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelDesk.Models;
using TravelDesk.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelDesk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminRepository _repo;

        public AdminController(IAdminRepository userRepository)
        {
            _repo = userRepository;
        }

        // GET api/user
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var users = await _repo.GetAllAsync();
            return Ok(users);
        }

        // GET api/user/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var user = await _repo.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // POST api/user
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("Invalid user data.");
            }

            try
            {
                var createdUser = await _repo.AddAsync(user);
                return CreatedAtAction(nameof(Details), new { id = createdUser.Id }, createdUser);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, $"Database update error: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT api/user/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody] User user)
        {
            if (id != user.Id)
            {
                return BadRequest("User ID mismatch.");
            }

            try
            {
                var updatedUser = await _repo.UpdateAsync(id, user);
                if (updatedUser == null)
                {
                    return NotFound();
                }
                return Ok(updatedUser);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, $"Database update error: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE api/user/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _repo.DeleteAsync(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }

        // GET api/user/managers
        [HttpGet("managers")]
        public async Task<ActionResult<IEnumerable<User>>> GetManagers()
        {
            var managers = await _repo.GetManagersAsync();
            return Ok(managers);
        }
    }
}
