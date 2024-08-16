using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelDesk.Context;
using TravelDesk.Models;
using TravelDesk.viewModel;

namespace TravelDesk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        TravelDeskContext _context;
        public LoginController(TravelDeskContext context)
        {
            _context = context; 
        }

        [HttpPost("login")]
        public IActionResult Login(LoginModel loginModel)
        {
            var user=_context.Users .FirstOrDefault(x=>x.Email==loginModel.Email
            &&  x.Password ==loginModel.Password);
            return Ok(user);
        }

    }
}
