using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Timesheets.Data.Entities;
using Timesheets.Services.Abstracts;
using Timesheets.Validations.EntityValidators.Abstract;

namespace Timesheets.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/contracts")]
    public class ContractController : Controller
    {
        private readonly IContractService _contractService;
        private readonly IContractValidationService _contractValidationService;

        public ContractController(
            IContractService contractService,
            IContractValidationService contractValidationService)
        {
            _contractService = contractService;
            _contractValidationService = contractValidationService;
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
            var validation = _contractValidationService.ValidateEntity(contractNew);
            if (!validation.Succeed)
            {
                return BadRequest(validation);
            }

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
