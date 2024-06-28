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
        public IActionResult GetSessionType(int id)
        {
            return Ok(_service.GetSessionType(id));
        }
        [HttpPost]
        public IActionResult AddSessionType([FromBody] SessionTypeRequest sessionType)
        {
            if (_service.AddSessionType(sessionType))
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpPut]
        public IActionResult UpdateSessionType([FromBody] SessionTypeRequest sessionType)
        {
            if (_service.UpdateSessionType(sessionType))
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSessionType(int id)
        {
            if (_service.DeleteSessionType(id))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
