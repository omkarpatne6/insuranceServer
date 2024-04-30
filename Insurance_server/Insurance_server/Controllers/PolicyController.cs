using Insurance_server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Insurance_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolicyController : ControllerBase
    {

        private readonly InsuranceDbContext _context;

        public PolicyController(InsuranceDbContext context)
        {
            _context = context;
        }

        [HttpGet("{userId}")]
        public IActionResult GetPolicies(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest("User ID not provided in route parameter");
            }

            if (!int.TryParse(userId, out int userIdInt))
            {
                return BadRequest("Invalid user ID format");
            }

            var policies = _context.PolicyDetails.Where(p => p.Eid == userIdInt).ToList();

            if (policies.Count == 0)
            {
                return NotFound("No policies found for the provided user ID");
            }

            return Ok(policies);
        }
    }
}
