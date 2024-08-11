using BusinessObjects.DTOs.Request;
using BusinessObjects.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionTypesController : ControllerBase
    {
        private readonly ISessionTypeService _service;
        public SessionTypesController(ISessionTypeService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult GetSessionTypes()
        {
            return Ok(_service.GetSessionTypes());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSessionType(int id)
        {
            return Ok(await _service.GetSessionType(id));
        }
        [HttpPost]
        public async Task<IActionResult> AddSessionType([FromBody] SessionTypeRequest sessionType)
        {
            if (await _service.AddSessionType(sessionType))
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateSessionType([FromBody] SessionTypeRequest sessionType)
        {
            if (await _service.UpdateSessionType(sessionType))
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSessionType(int id)
        {
            if (await _service.DeleteSessionType(id))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
