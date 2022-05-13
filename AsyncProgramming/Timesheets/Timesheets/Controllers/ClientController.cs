using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Timesheets.Data.Entities;
using Timesheets.Services.Abstracts;

namespace Timesheets.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/clients")]
    public class ClientController : Controller
    {
            private readonly IClientService _clientService;

            public ClientController(IClientService clientService)
            {
                _clientService = clientService;
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
