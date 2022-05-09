using Microsoft.AspNetCore.Mvc;
using Timesheets.Data.Entities;
using Timesheets.Services.Abstracts;

namespace Timesheets.Controllers
{
    [Route("api/contracts")]
    public class ContractController : Controller
    {
        private readonly IContractService _contractService;

        public ContractController(IContractService contractService)
        {
            _contractService = contractService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create()
        {
            var newContract = await _contractService.CreateAsync();
            return Ok(newContract);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var contract = await _contractService.GetAsync(id);
            return Ok(contract);
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var contracts = await _contractService.GetAllAsync();
            return Ok(contracts);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(long id, [FromBody]Contract contractNew)
        {
            await _contractService.UpdateAsync(id, contractNew);
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Remove(long id)
        {
            await _contractService.RemoveAsync(id);
            return Ok();
        }
    }
}
