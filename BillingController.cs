using HealthcareApi.Services.DTOs.Billing;
using HealthcareApi.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HealthcareApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillingController : ControllerBase
    {
        private readonly IBillingService _billingService;

        public BillingController(IBillingService billingService)
        {
            _billingService = billingService;
        }

        // GET: api/Billing
        [HttpGet]
        public async Task<IActionResult> GetAllBillings()
        {
            var billings = await _billingService.GetAllBillings();
            return Ok(billings);
        }

        // GET: api/Billing/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBillingById(int id)
        {
            var billing = await _billingService.GetBillingById(id);

            if (billing == null)
            {
                return NotFound(new
                {
                    Message = "Billing record not found."
                });
            }
            return Ok(billing);
        }

        // POST: api/Billing
        [HttpPost]
        public async Task<IActionResult> CreateBilling([FromBody] CreateBillingDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var billing = await _billingService.AddBilling(dto);

            return CreatedAtAction(
                nameof(GetBillingById),
                new { id = billing.BillId },
                billing);
        }

        // PUT: api/Billing/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBilling(int id, [FromBody] UpdateBillingDto dto)
        {
            if (id != dto.BillId)
            {
                return BadRequest(new
                {
                    Message = "Bill ID mismatch."
                });
            }

            var billing = await _billingService.UpdateBilling(dto);

            if (billing == null)
            {
                return NotFound(new
                {
                    Message = "Billing record not found."
                });
            }

            return Ok(new
            {
                Message = "Billing updated successfully.",
                Data = billing
            });
        }

        // DELETE: api/Billing/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBilling(int id)
        {
            var deleted = await _billingService.DeleteBilling(id);

            if (!deleted)
            {
                return NotFound(new
                {
                    Message = "Billing record not found."
                });
            }

            return Ok(new
            {
                Message = "Billing deleted successfully."
            });
        }
    }
}










