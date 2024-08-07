using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TravelDesk.Context;
using TravelDesk.Models;
using TravelDesk.Repositories;

namespace TravelDesk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repo;

        private readonly UserDBContext _context; 

        public UserController(IUserRepository userRepository, UserDBContext context)
        {
            _repo = userRepository;
            _context = context; 
        }

        // GET api/user
        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_repo.GetAll());
        }

        // GET api/user/{id}
        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {
            var user = _repo.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        


        [HttpPost]
        public IActionResult Create([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("Invalid user data.");
            }

            try
            {
                var createdUser = _repo.AddUser(user);
                return CreatedAtAction(nameof(Create), new { id = createdUser.Id }, createdUser);
            }
            catch (DbUpdateException ex)
            {
                // Log the exception and return a detailed error response
                // You might use a logging library or write to a log file
                return StatusCode(500, $"Database update error: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Log the exception and return a generic error response
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        // PUT api/user/{id}
        [HttpPut("{id}")]
        public IActionResult Edit(int id, [FromBody] User user)
        {
            var updatedUser = _repo.UpdateUser(id, user);
            if (updatedUser == null)
            {
                return NotFound();
            }
            return Ok(updatedUser);
        }

        // DELETE api/user/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var success = _repo.DeleteUser(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpGet("managers")]
        public async Task<ActionResult<IEnumerable<User>>> GetManagers()
        {
            var managers = await _context.Users
                .Where(u => u.Role.RoleName == "Manager" && u.IsActive)
                .ToListAsync();

            return Ok(managers);

        }

        ///get roles roll id and role name
        ///get managers 
    }
}
