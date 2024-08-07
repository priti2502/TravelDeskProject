using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelDesk.Context;
using TravelDesk.Models;

namespace TravelDesk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly UserDBContext _context; 

        public RoleController(UserDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Role>> GetRoles()
        {
            // Fetch roles with RoleName "Admin"
            var adminRoles = _context.Roles
                .Where(role => role.RoleName != "Admin")
                .Select(role => new Role
                {
                    RoleId = role.RoleId,
                    RoleName = role.RoleName
                })
                .ToList();

            return Ok(adminRoles);
        }
        //[HttpGet]
        //public ActionResult<IEnumerable<User>> GetManagers()
        //{
        //    // Assuming you have a DbSet<Manager> in your ApplicationDbContext
        //    var managers = _context.Users.ToList();
        //    return Ok(managers);
        //}
    }
}
