using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Timesheets.Data.Entities;
using Timesheets.Services.Abstracts;
using Timesheets.Validations.EntityValidators.Abstract;

namespace Timesheets.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/clients")]
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;
        private readonly IClientValidationService _clientValidationService;

        public ClientController(
            IClientService clientService,
            IClientValidationService clientValidationService)
        {
            _clientService = clientService;
            _clientValidationService = clientValidationService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create()
        {
            var newClient = await _clientService.CreateAsync();
            return Ok(newClient);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var client = await _clientService.GetAsync(id);
            return Ok(client);
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var clients = await _clientService.GetAllAsync();
            return Ok(clients);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] Client clientNew)
        {
            var validation = _clientValidationService.ValidateEntity(clientNew);
            if (!validation.Succeed)
            {
                return BadRequest(validation);
            }

            await _clientService.UpdateAsync(id, clientNew);
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Remove(long id)
        {
            await _clientService.RemoveAsync(id);
            return Ok();
        }
    }
}
