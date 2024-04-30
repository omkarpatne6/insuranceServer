using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Insurance_server.Models;

namespace Insurance_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentDetailController : ControllerBase
    {
        private readonly InsuranceDbContext _context;

        public PaymentDetailController(InsuranceDbContext context)
        {
            _context = context;
        }

        // GET: api/PaymentDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentDetail>>> GetPaymentDetails()
        {
            return await _context.PaymentDetails.ToListAsync();
        }

        [HttpGet("{eid}")]
        public async Task<ActionResult<IEnumerable<PaymentDetail>>> GetPaymentDetailsByEid(string eid)
        {

            if (!int.TryParse(eid, out int userIdInt))
            {
                return BadRequest("Invalid user ID format");
            }

            var paymentDetails = await _context.PaymentDetails.Where(p => p.Eid == userIdInt).ToListAsync();

            if (paymentDetails == null || !paymentDetails.Any())
            {
                return NotFound();
            }

            return paymentDetails;
        }

        // GET: api/PaymentDetail/5
 /*       [HttpGet("{id}")]
        public async Task<ActionResult<PaymentDetail>> GetPaymentDetail(int id)
        {
            var paymentDetail = await _context.PaymentDetails.FindAsync(id);
            
            if (paymentDetail == null)
            {
                return NotFound();
            }

            return paymentDetail;
        }*/

        [HttpPost]
        public async Task<IActionResult> Post(PaymentDetail payment)
        {
            _context.Add(payment);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(PaymentDetail payment)
        {
            if (payment == null || payment.PaymentId == 0)
                return BadRequest();

            var productInfo = await _context.PaymentDetails.FindAsync(payment.PaymentId);
            if (productInfo == null)
                return NotFound();
            productInfo.CardOwnerName = payment.CardOwnerName;
            productInfo.CardNumber = payment.CardNumber;
            productInfo.SecurityCode = payment.SecurityCode;
            productInfo.ValidThrough = payment.ValidThrough;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 1)
                return BadRequest();
            var paymentInfo = await _context.PaymentDetails.FindAsync(id);
            if (paymentInfo == null)
                return NotFound();
            _context.PaymentDetails.Remove(paymentInfo);
            await _context.SaveChangesAsync();
            return Ok();

        }

        private bool PaymentDetailExists(int id)
        {
            return _context.PaymentDetails.Any(e => e.PaymentId == id);
        }
    }
}
