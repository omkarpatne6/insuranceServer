using Insurance_server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Insurance_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {

        private readonly InsuranceDbContext _context;

        public ProfileController(InsuranceDbContext context)
        {
            _context = context;
        }

        // GET: api/Profile/{userId}
        [HttpGet("{userId}")]
        public async Task<ActionResult<UserLoginDetail>> GetUserProfile(int userId)
        {
            var user = await _context.UserLoginDetails.FindAsync(userId);

            if (user == null)
            {
                return NotFound();
            }

            // Return the user details
            return user;
        }


    }
}
