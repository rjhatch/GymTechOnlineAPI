using GymTechOnlineAPI.Models;
using GymTechOnlineAPI.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GymTechOnlineAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly PaymentService _paymentService;

        public PaymentsController(PaymentService PaymentService) =>
            _paymentService = PaymentService;

        // GET: api/<PaymentsController>
        [HttpGet]
        public async Task<List<Payment>> Get() => await _paymentService.GetAsync();

        // GET api/<PaymentsController>/5
        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Payment>> Get(string id)
        {
            var payment = await _paymentService.GetAsync(id);

            if (payment is null)
            {
                return NotFound();
            }

            return payment;
        }

        // POST api/<PaymentsController>
        [HttpPost]
        public async Task<IActionResult> Post(Payment newPayment)
        {
            await _paymentService.CreateAsync(newPayment);

            return CreatedAtAction(nameof(Get), new { id = newPayment.Id }, newPayment);
        }

        // PUT api/<PaymentsController>/5
        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Payment updatedPayment)
        {
            var payment = await _paymentService.GetAsync(id);

            if (payment is null)
            {
                return NotFound();
            }

            updatedPayment.Id = payment.Id;

            await _paymentService.UpdateAsync(id, updatedPayment);

            return NoContent();
        }

        // DELETE api/<PaymentsController>/5
        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var payment = await _paymentService.GetAsync(id);

            if (payment is null)
            {
                return NotFound();
            }

            await _paymentService.RemoveAsync(payment.Id);

            return NoContent();
        }
    }
}
