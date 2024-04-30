using Insurance_server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Insurance_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly InsuranceDbContext _context;

        public LoginController(InsuranceDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Authenticate([FromBody] LoginRequest model)
        {
            var user = _context.UserLoginDetails.SingleOrDefault(u => u.Email == model.Email);

            if (user == null)
            {
                return NotFound("User not found"); 
            }

            if (user.Password != model.Password)
            {
                return BadRequest("Incorrect password");
            }

            return Ok(user);
        }
    }
}
