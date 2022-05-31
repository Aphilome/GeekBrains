using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Timesheets.Data.Entities;
using Timesheets.Services.Abstracts;
using Timesheets.Validations.EntityValidators.Abstract;

namespace Timesheets.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/invoices")]
    public class InvoiceController : Controller
    {
        private readonly IInvoiceService _invoiceService;
        private readonly IInvoiceValidationService _invoiceValidationService;

        public InvoiceController(
            IInvoiceService invoiceService,
            IInvoiceValidationService invoiceValidationService)
        {
            _invoiceService = invoiceService;
            _invoiceValidationService = invoiceValidationService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create()
        {
            var newInvoice = await _invoiceService.CreateAsync();
            return Ok(newInvoice);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var invoice = await _invoiceService.GetAsync(id);
            return Ok(invoice);
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var invoices = await _invoiceService.GetAllAsync();
            return Ok(invoices);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] Invoice newInvoice)
        {
            var validation = _invoiceValidationService.ValidateEntity(newInvoice);
            if (!validation.Succeed)
            {
                return BadRequest(validation);
            }

            await _invoiceService.UpdateAsync(id, newInvoice);
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Remove(long id)
        {
            await _invoiceService.RemoveAsync(id);
            return Ok();
        }
    }
}
