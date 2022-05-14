using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Timesheets.Data.Entities;
using Timesheets.Services.Abstracts;
using Timesheets.Validations.EntityValidators.Abstract;

namespace Timesheets.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/employees")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IEmployeeValidationService _employeeValidationService;

        public EmployeeController(
            IEmployeeService employeeService,
            IEmployeeValidationService employeeValidationService)
        {
            _employeeService = employeeService;
            _employeeValidationService = employeeValidationService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create()
        {
            var newEmployee = await _employeeService.CreateAsync();
            return Ok(newEmployee);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var employee = await _employeeService.GetAsync(id);
            return Ok(employee);
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var employees = await _employeeService.GetAllAsync();
            return Ok(employees);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] Employee newEmployee)
        {
            var validation = _employeeValidationService.ValidateEntity(newEmployee);
            if (!validation.Succeed)
            {
                return BadRequest(validation);
            }

            await _employeeService.UpdateAsync(id, newEmployee);
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Remove(long id)
        {
            await _employeeService.RemoveAsync(id);
            return Ok();
        }
    }
}
