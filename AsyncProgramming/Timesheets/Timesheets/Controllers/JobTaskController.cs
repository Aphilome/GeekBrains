using Microsoft.AspNetCore.Mvc;
using Timesheets.Data.Entities;
using Timesheets.Services.Abstracts;

namespace Timesheets.Controllers
{
    [Route("api/job-tasks")]
    public class JobTaskController : Controller
    {
        private readonly IJobTaskService _jobTaskService;

        public JobTaskController(IJobTaskService jobTaskService)
        {
            _jobTaskService = jobTaskService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create()
        {
            var newJobTask = await _jobTaskService.CreateAsync();
            return Ok(newJobTask);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var jobTask = await _jobTaskService.GetAsync(id);
            return Ok(jobTask);
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var jobTasks = await _jobTaskService.GetAllAsync();
            return Ok(jobTasks);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] JobTask jobTaskNew)
        {
            await _jobTaskService.UpdateAsync(id, jobTaskNew);
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Remove(long id)
        {
            await _jobTaskService.RemoveAsync(id);
            return Ok();
        }
    }
}
