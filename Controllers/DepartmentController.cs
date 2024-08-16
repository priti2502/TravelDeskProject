using Microsoft.AspNetCore.Mvc;
using TravelDesk.Context;
using TravelDesk.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TravelDesk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly TravelDeskContext _context;

        public DepartmentController(TravelDeskContext context)
        {
            _context = context;
        }

        [HttpGet("departments")]
        public async Task<ActionResult<List<Department>>> GetDepartments()
        {
            var departments = await _context.Departments.ToListAsync();
            return Ok(departments);
        }

       
    }
}
