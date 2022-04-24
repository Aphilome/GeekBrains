using Microsoft.AspNetCore.Mvc;
using Timesheets.Data.Dto;

namespace Timesheets.Controllers
{
    [Route("api/contracts")]
    public class ContractController : Controller
    {
        [HttpPost("create")]
        public IActionResult Create()
        {
            
            return null;
        }

        [HttpGet("get/{id}")]
        public IActionResult Get(long id)
        {

        }

        [HttpGet("get-all")]
        public IActionResult GetAll()
        {

        }

        [HttpPut("update/{id}")]
        public IActionResult Update(long id, [FromBody]ContractDto contractDto)
        {

        }

        [HttpDelete("delete/{id}")]
        public IActionResult Remove(long id)
        {

        }
    }
}
